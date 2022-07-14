namespace DSRSummerPractice.Shared.Interfaces;

using System;
using System.Collections.Generic;

public interface IRepository<T> where T : class
{
    IEnumerable<T> find(DateTime start, DateTime end);
    T find(DateTime date);
}