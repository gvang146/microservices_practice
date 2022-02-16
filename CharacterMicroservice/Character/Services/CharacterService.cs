using CharacterAPI.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterAPI.Services
{
    public class CharacterService
    {
        private readonly IMongoCollection<Character> Characters;
        public CharacterService()
        {

        }
        public CharacterService(IOptions<CharacterDBSettings> settings)
        {
            var charaClient = new MongoClient(settings.Value.ConnectionString);
            var database = charaClient.GetDatabase(settings.Value.DatabaseName);
            Characters = database.GetCollection<Character>(settings.Value.CollectionName);
        }
        
        //return list of characters
        public async Task<List<Character>> GetAsync() =>
           await Characters.Find(chara => true).ToListAsync();
        //return a character by id
        public async Task<Character?> GetAsync(string id) =>
              await Characters.Find<Character>(chara => chara.Id == id).FirstOrDefaultAsync();
        //create a new character and add to database
        public async Task CreateAsync(Character newChara) =>
            await Characters.InsertOneAsync(newChara);
        //update an existing character
        public async Task UpdateAsync(string id, Character updated) =>
            await Characters.ReplaceOneAsync(x => x.Id == id, updated);
        //Delete an existing character base on id
        public async Task RemoveAsync(string id) =>
            await Characters.DeleteOneAsync(x => x.Id == id);

    }
}
