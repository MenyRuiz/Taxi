using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Common.Enums;
using Taxi.Web.Data.Entities;
using Taxi.Web.Helpers;

namespace Taxi.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "jzuluaga55@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            var driver = await CheckUserAsync("2020", "Juan", "Zuluaga", "jzuluaga55@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Driver);
            var user1 = await CheckUserAsync("3030", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            var user2 = await CheckUserAsync("4040", "Juan", "Zuluaga", "juanzuluaga2480@correo.itm.edu.co", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckTaxisAsync(driver, user1, user2);
        }

        private async Task<UserEntity> CheckUserAsync(
           string document,
           string firstName,
           string lastName,
           string email,
           string phone,
           string address,
           UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        

        private async Task CheckTaxisAsync(
             UserEntity driver,
             UserEntity user1,
             UserEntity user2)
        {
            if (!_dataContext.Taxis.Any())
            {
                _dataContext.Taxis.Add(new TaxiEntity
                {
                    User = driver,
                    plaque = "TPQ124",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vulputate sem dignissim, faucibus mi ut, accumsan dui. Mauris tristique imperdiet lacus a fermentum. Praesent ut commodo lorem. Nam eget gravida tellus. Sed laoreet, nisl non varius sollicitudin, arcu tellus varius sapien, nec ullamcorper velit eros iaculis dui. Donec aliquam, urna a porta elementum, velit odio ornare quam, sed feugiat tellus dolor eu eros. Aenean ornare finibus iaculis. Quisque aliquam odio vel vehicula condimentum. Nam eros nibh, mollis facilisis sagittis et, aliquet non leo. Suspendisse quis maximus tortor. In varius, sem eu euismod tristique, ligula felis lobortis ex, vel condimentum massa tellus sit amet tortor.",
                            User = user1
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Vestibulum tincidunt nibh est, sed rutrum neque pretium ac. In hac habitasse platea dictumst. Phasellus eu suscipit massa. Proin id urna lorem. Cras ac mattis metus. Curabitur auctor, ex ut pellentesque porttitor, arcu dui ultrices massa, nec sagittis arcu quam sit amet nulla. Aenean eget egestas velit. Nam velit nisi, blandit quis est sed, laoreet varius nunc. Maecenas pellentesque gravida enim vitae convallis. Donec tempor bibendum justo, at ultricies neque feugiat quis. Suspendisse id pharetra ex. Vivamus auctor risus molestie ipsum luctus, eget dictum purus placerat. Suspendisse faucibus fringilla felis, vel elementum orci sagittis in. Nulla porta libero et aliquet scelerisque. Proin mattis aliquet nisi eu porta.",
                            User = user1
                        }
                    }
                });

                _dataContext.Taxis.Add(new TaxiEntity
                {
                    plaque = "THW321",
                    User = driver,
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            User = user2
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            User = user2
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

