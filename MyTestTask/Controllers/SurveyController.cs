using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTestTask.Database.Context;
using MyTestTask.Entities;

namespace MyTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveyController : ControllerBase
{
    private readonly MyDbContext _db;

    public SurveyController(MyDbContext myDbContext) => _db = myDbContext;

    [HttpGet("question/{id}")]
    public async Task<IActionResult> GetQuestion(int id)
    {
        var question = await _db.Questions
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.Id == id);
        
        return question is null ? NotFound() : Ok(question);
    }

    [HttpPost("answer")]
    public async Task<IActionResult> SaveAnswer([FromBody] Result result)
    {
        await _db.Results.AddAsync(result);
        await _db.SaveChangesAsync();
        
        var nextQuestion = await _db.Questions
            .Where(q => q.Id == result.QuestionId)
            .OrderBy(q => q.Id)
            .FirstOrDefaultAsync();
        
        return nextQuestion is null ? Ok("Survey completed") : Ok(new { nextQuestionId = nextQuestion.Id });
    }
}