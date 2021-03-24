using MarsRoverProblem.Models;
using MarsRoverProblem.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProblem.Repositories
{
    public interface IRepository<T> where T:class
    {
        ResponseBase CanIDo(T item, Plateau plateau);
        ResponseBase Move(T item, Plateau plateau);
        void Rotate(T item, char key);
        //ResponseBase Move(ref T item, Plateau plateau);
        //void Rotate(ref T item, char key);
    }
}
