using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GenreService
    {
        private IGenreRepository genreRepository;

       public GenreService(IGenreRepository genreRepository)
       {
            if (genreRepository == null)
            {
                throw new ArgumentNullException("Genre repository is null");
            }

            this.genreRepository = genreRepository;
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

        public IReadOnlyList<Artist> GetAllArtistBaseOnGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentException("Genre is null");
            }

            List<Artist> artists = new List<Artist>();
            IReadOnlyList<ArtistDTO> artistDtos = genreRepository.GetAllArtistBaseOnGenre(new GenreDTO(genre.name));

            foreach (ArtistDTO artistDto in artistDtos)
            {
                artists.Add(new Artist(artistDto.name));
            }

            return artists.AsReadOnly();
        }
    }
}
