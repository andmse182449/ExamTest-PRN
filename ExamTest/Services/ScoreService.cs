using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repository.Models;
using static System.Formats.Asn1.AsnWriter;


namespace Services
{
    public class ScoreService
    {
        ScoreRepository _repo;
        public void CreateAScore(Score score) {
            _repo = new ScoreRepository();
            _repo.Create(score);
        }

        public Score GetAScore(String lesID, String accID)
        {
            _repo = new ScoreRepository();
           return _repo.Get(lesID, accID);
        }
        public List<Score> GetList(string id)
        {
            ScoreRepository scoreRepository = new ScoreRepository();
            return scoreRepository.GetAll(id);
        }
    }
}
