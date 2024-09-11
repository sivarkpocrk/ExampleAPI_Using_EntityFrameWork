[ApiController]
[Route("Author")]
[SwaggerTag("Author data (AUTHOR)")]
[Tags("Author Infos")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        var authorsDto = _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        return Ok(authorsDto);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorById(int id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        var authorDto = _mapper.Map<AuthorDTO>(author);
        return Ok(authorDto);
    }

    [HttpPost("create")]
    public async Task<ActionResult<AuthorDTO>> CreateAuthor([FromBody] AuthorDTO authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        await _authorService.AddAuthorAsync(author);
        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, authorDto);
    }
}
