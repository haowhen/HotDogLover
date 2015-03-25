using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using AutoMapper;
using HotDogLover.Models.HotDog;
using HotDogLover.Models.Profile;
using Microsoft.Ajax.Utilities;
using Profile = HotDogLover.Models.Profile.Profile;

namespace HotDogLover.Service
{
    public class ProfileService
    {
        private static List<Profile> _profiles;


        static ProfileService()
        {
            _profiles = PopulateProfiles();
        }

        public IEnumerable<ProfileIndexViewModel> GetProfileIndexViewModels()
        {
            Mapper.CreateMap<Profile, ProfileIndexViewModel>()
                .ForMember(dest => dest.FavoriteDog, e => e.MapFrom(src => src.FavoriteDog.Name));

            return _profiles.ToList().Select(Mapper.Map<ProfileIndexViewModel>).ToList();
        }

        public Profile GetProfile(Guid id)
        {
            var foundProfile = new Profile();
            foreach (var profile in _profiles.Where(profile => profile.Id == id))
            {
                foundProfile = profile;
            }

            return foundProfile;
        }

        public ProfileUpdateViewModel GetProfileUpdateViewModel(Guid id)
        {
            Mapper.CreateMap<Profile, ProfileUpdateViewModel>();

            var result = Mapper.Map<ProfileUpdateViewModel>(_profiles.First(p => p.Id == id));

            result.FavoriteDog.Date = _profiles.First(p => p.Id == id).FavoriteDog.Date;

            return result;
        }

        public void Update(ProfileUpdateViewModel viewModel)
        {
            Mapper.CreateMap<ProfileUpdateViewModel, Profile>();

            Mapper.Map(viewModel, _profiles.First(p => p.Id == viewModel.Id));
        }

        public HotDogCreateViewModel GetHotDogCreateViewModel(Guid profileId)
        {
            Mapper.CreateMap<HotDog, HotDogCreateViewModel>();
            Mapper.CreateMap<Profile, HotDogCreateViewModel>()
                .ForMember(dest => dest.ProfileId, e => e.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, e => e.Ignore())
                .ForMember(dest => dest.Date, e => e.Ignore());

            var result = Mapper.Map<HotDogCreateViewModel>(_profiles.First(p => p.Id == profileId));

            return result;
        }

        public void CreateHotDogViewModel(HotDogCreateViewModel viewModel)
        {
            Mapper.CreateMap<HotDogCreateViewModel, HotDog>();

            var profile = _profiles.Find(p => p.Id == viewModel.ProfileId);

            profile.HotDogs.Add(Mapper.Map<HotDog>(viewModel));
            
        }

        private static List<Profile> PopulateProfiles()
        {
            var profiles = new List<Profile>();
            var p1 = new Profile
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                              "Ut tristique id nunc sit amet interdum. Etiam mollis sem ipsum, " +
                              "ac gravida est placerat non. " +
                              "Mauris ligula purus, egestas in mattis a, consectetur at dui. " +
                              "Mauris aliquet sollicitudin erat. Etiam lacinia consectetur tortor, at varius libero imperdiet ac. Donec et ligula in est faucibus viverra. Fusce molestie eleifend mi non convallis. " +
                              "Vivamus posuere at libero sit amet imperdiet. " +
                              "Pellentesque faucibus sit amet lacus sollicitudin iaculis. " +
                              "Integer ultrices feugiat tempus. " +
                              "Nulla ultricies, nisi nec consequat viverra, sem enim pulvinar felis, " +
                              "at dictum enim ligula eu nulla. Donec dictum convallis cursus. " +
                              "Fusce vitae urna ipsum. Nam interdum nibh neque, quis facilisis eros hendrerit nec. " +
                              "Nunc euismod est non imperdiet ultrices.",
                FavoriteDog = new HotDog
                {
                    Date = new DateTime(2014, 1, 12),
                    Name = "All Beef"
                },
                LastAte = "Tom's Wagon",
                Rating = 1,
                HotDogs = new List<HotDog>
                {
                    new HotDog(){Date = new DateTime(2014, 01, 12), Id = Guid.NewGuid(), Name = "All Beef"},
                    new HotDog(){Date = new DateTime(2014, 01, 12), Id = Guid.NewGuid(), Name = "Vegan Delight"},
                    new HotDog(){Date = new DateTime(2014, 01, 12), Id = Guid.NewGuid(), Name = "Purple People Eater"}                  
                }

            };

            profiles.Add(p1);

            return profiles;
        }
    }
}