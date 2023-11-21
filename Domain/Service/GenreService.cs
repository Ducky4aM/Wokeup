using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GenreService
    {
        private GenreRepository genreRepository;

        public GenreService()
        {
           this.genreRepository = new GenreRepository();
        }

        public IReadOnlyList<Genre> GetAllGenre()
        {
            List<Genre> genres = new List<Genre>();
            IReadOnlyList<GenreDTO> genreDtos = this.genreRepository.GetAllGenre();

            foreach (GenreDTO genreDto in genreDtos)
            {
                genres.Add(new Genre(genreDto.name));
            }

            return genres.AsReadOnly();
        }

        public IReadOnlyList<Genre> GetUserPreferGenres(User user)
        {
            try
            {
                UserDTO userDto = new UserDTO(user.id);

                IReadOnlyList<GenreDTO> genreDtos= this.genreRepository.GetUserPreferGenres(userDto);

                foreach (GenreDTO genreDto in genreDtos)
                {
                    user.AddPreferGenre(new Genre(genreDto.name));
                }

                return user.GetPreferGenres();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
