using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IPlainsRepository
    {
        PlainModel GetPlain(int plainId);

        IEnumerable<PlainModel> GetAll();

        void Add(PlainModel plain);

        void Remove(int plainId);

        void Update(PlainModel plain);
    }
}
