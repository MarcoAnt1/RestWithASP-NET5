﻿using RestWithASP_NET5.Data.Converter.Contract;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return null;

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public Book Parse(BookVO origin)
        {

            if (origin == null)
                return null;

            return new Book
            { 
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
    }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
                return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
