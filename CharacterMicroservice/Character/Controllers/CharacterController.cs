using CharacterAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _charaService;

        private readonly ILogger<CharacterController> _logger;

        public CharacterController(CharacterService charaService, ILogger<CharacterController> logger)
        {
            _charaService = charaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Character>> Get() =>
           await _charaService.GetAsync();
        //returning a character
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Character>> Get(string id)
        {
            var chara = await _charaService.GetAsync(id);
            if (chara == null)
            {
                return NotFound();
            }
            return chara;
        }
        //creating a new character
        [HttpPost]
        public async Task<IActionResult> Post(Character newChara)
        {
            await _charaService.CreateAsync(newChara);
            return CreatedAtAction(nameof(Get), new { id = newChara.Id }, newChara);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Character updated)
        {
            var chara = await _charaService.GetAsync(id);
            if (chara == null)
            {
                return NotFound();
            }
            updated.Id = chara.Id;
            await _charaService.UpdateAsync(id, updated);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var chara = await _charaService.GetAsync(id);
            if (chara == null)
            {
                return NotFound();
            }
            await _charaService.RemoveAsync(id);
            return NoContent();
        }
    }
}
