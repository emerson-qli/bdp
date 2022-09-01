using ERC.Framework.Security;
using Domain.Configurations;
using Domain.Enums;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations {
    public class BPHDbInitializer : DropCreateDatabaseIfModelChanges<BPHDbContext> {
        protected override void Seed(BPHDbContext context) {

            #region settings

            var settingRepository = new SettingRepository();
            new List<Setting> {
                new Setting {
                    Name  = "ImagePath",
                    Value = "C:/inetpub/wwwroot/wbb.olongapo/Content/img/pictures/",
                    Group = "Path"
                },
                new Setting {
                    Name  = "Theme",
                    Value = "",
                    Group = "Setting"
                },
                new Setting {
                    Name  = "Text Editor",
                    Value = "Default",
                    Group = "Setting"
                },
                new Setting {
                    Name  = "Font",
                    Value = "",
                    Group = "Setting"
                },
                new Setting {
                    Name  = "Font Style",
                    Value = "",
                    Group = "Setting"
                },
                new Setting {
                    Name  = "Threshold for expiring documents",
                    Value = "",
                    Group = "Setting"
                },
                new Setting {
                    Name  = "Recipients for expiring documents",
                    Value = "",
                    Group = "Setting"
                },
            }.ForEach(a => settingRepository.Add(a));
            settingRepository.Save();

            #endregion

            #region Roles


            var roleRepository = new RoleRepository();

            var roleId1 = Guid.NewGuid(); //astronaut
            var roleId2 = Guid.NewGuid(); //admin
            var roleId3 = Guid.NewGuid(); //user

            var roles = new List<Role> {
                new Role{
                    Id          = roleId1,
                    RoleType    = RoleType.Astronaut,
                    Name        = "Super Admin",
                    Description = "Super Admin",
                    Tag         = RoleState.Active
                },
                new Role{
                    Id          = roleId2,
                    RoleType    = RoleType.Admin,
                    Name        = "Admin",
                    Description = "Admin",
                    Tag         = RoleState.Active
                },
                new Role{
                    Id          = roleId3,
                    RoleType    = RoleType.Others,
                    Name        = "User",
                    Description = "User",
                    Tag         = RoleState.Active

                },
            };

            roles.ForEach(a => roleRepository.Add(a));
            roleRepository.Save();

            #endregion

            #region Users

            var defaultPassword = "build1156";

            var user1  = Guid.NewGuid();
            var user2  = Guid.NewGuid();
            var user3  = Guid.NewGuid();
            var user4  = Guid.NewGuid();
            var user5  = Guid.NewGuid();
            var user6  = Guid.NewGuid();
            var user7  = Guid.NewGuid();
            var user8  = Guid.NewGuid();
            var user9  = Guid.NewGuid();
            var user10 = Guid.NewGuid();
            var user11 = Guid.NewGuid();
            var user12 = Guid.NewGuid();
            var user13 = Guid.NewGuid();
            var user14 = Guid.NewGuid();
            var user15 = Guid.NewGuid();
            var user16 = Guid.NewGuid();
            var user17 = Guid.NewGuid();
            var user18 = Guid.NewGuid();
            var user19 = Guid.NewGuid();
            var user20 = Guid.NewGuid();
            var user21 = Guid.NewGuid();
            var user22 = Guid.NewGuid();
            var user23 = Guid.NewGuid();
            var user24 = Guid.NewGuid();
            var user25 = Guid.NewGuid();
            var user5b = Guid.NewGuid();

            var userRepository = new UserRepository();

            var users = new List<User> {
                new User{
                    Id          = user1,
                    Username    = "ecristobal@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId1

                },
                new User{
                    Id          = user2,
                    Username    = "jramboyong@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId2

                },
                new User{
                    Id          = user3,
                    Username    = "epike@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user4,
                    Username    = "dpruitt@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user5,
                    Username    = "dpruitt@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user5b,
                    Username    = "bmelo@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user6,
                    Username    = "icarvalho@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user7,
                    Username    = "mbalazs@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user8,
                    Username    = "alayborn@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user9,
                    Username    = "yhicken@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user10,
                    Username    = "gtreslove@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user11,
                    Username    = "kgon@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user12,
                    Username    = "tbruty@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user13,
                    Username    = "screany@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user14,
                    Username    = "jmountford@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user15,
                    Username    = "acoey@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user16,
                    Username    = "fgerbel@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user17,
                    Username    = "cdobrowolski@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user18,
                    Username    = "wrue@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user19,
                    Username    = "gionnidis@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user20,
                    Username    = "ecastelow@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user21,
                    Username    = "dhasty@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user22,
                    Username    = "rhalls@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
                new User{
                    Id          = user23,
                    Username    = "tgroombridge@buildanddox.ph",
                    Password    = new CryptographyHelper().CreateHash(defaultPassword),
                    CreatedAt   = DateTime.Now,
                    RoleId      = roleId3
                },
            };

            users.ForEach(a => userRepository.Add(a));
            userRepository.Save();
            #endregion

            #region RoleTemplate
            var roleTemplateRepository = new RoleTemplateRepository();

            System.Enum.GetValues(typeof(ApplicationElement))
                       .Cast<ApplicationElement>()
                       .ToList()
                       .ForEach(a => {
                           roleTemplateRepository.Add(new RoleTemplate {
                               Id                   = Guid.NewGuid(),
                               ApplicationElement   = a,
                               RoleId               = roleId1 //astronaut
                           });
                       });

            roleTemplateRepository.Save();


            System.Enum.GetValues(typeof(ApplicationElement))
                       .Cast<ApplicationElement>()
                       .Where(a => a.ToString().Contains("View") ||
                                   a.ToString().Contains("Save"))
                       .ToList()
                       .ForEach(a => {
                           roleTemplateRepository.Add(new RoleTemplate {
                               Id                   = Guid.NewGuid(),
                               ApplicationElement   = a,
                               RoleId               = roleId2 //administrator
                           });
                       });

            roleTemplateRepository.Save();


            System.Enum.GetValues(typeof(ApplicationElement))
                       .Cast<ApplicationElement>()
                       .Where(a => a.ToString().Contains("View"))
                       .ToList()
                       .ForEach(a => {
                           roleTemplateRepository.Add(new RoleTemplate {
                               Id                   = Guid.NewGuid(),
                               ApplicationElement   = a,
                               RoleId               = roleId2 //user
                           });
                       });

            roleTemplateRepository.Save();






            #endregion

            #region Locations
            var countryRepository = new CountryRepository();

            var countries = new List<Country> {
                new Country {Name="Afghanistan", Id = Guid.NewGuid()},
                new Country {Name="Albania", Id = Guid.NewGuid()},
                new Country {Name="Algeria", Id = Guid.NewGuid()},
                new Country {Name="American Samoa", Id = Guid.NewGuid()},
                new Country {Name="Andorra", Id = Guid.NewGuid()},
                new Country {Name="Angola", Id = Guid.NewGuid()},
                new Country {Name="Anguilla", Id = Guid.NewGuid()},
                new Country {Name="Antarctica", Id = Guid.NewGuid()},
                new Country {Name="Antigua And Barbuda", Id = Guid.NewGuid()},
                new Country {Name="Argentina", Id = Guid.NewGuid()},
                new Country {Name="Armenia", Id = Guid.NewGuid()},
                new Country {Name="Aruba", Id = Guid.NewGuid()},
                new Country {Name="Australia", Id = Guid.NewGuid()},
                new Country {Name="Austria", Id = Guid.NewGuid()},
                new Country {Name="Azerbaijan", Id = Guid.NewGuid()},
                new Country {Name="Bahamas", Id = Guid.NewGuid()},
                new Country {Name="Bahrain", Id = Guid.NewGuid()},
                new Country {Name="Bangladesh", Id = Guid.NewGuid()},
                new Country {Name="Barbados", Id = Guid.NewGuid()},
                new Country {Name="Belarus", Id = Guid.NewGuid()},
                new Country {Name="Belgium", Id = Guid.NewGuid()},
                new Country {Name="Belize", Id = Guid.NewGuid()},
                new Country {Name="Benin", Id = Guid.NewGuid()},
                new Country {Name="Bermuda", Id = Guid.NewGuid()},
                new Country {Name="Bhutan", Id = Guid.NewGuid()},
                new Country {Name="Bolivia", Id = Guid.NewGuid()},
                new Country {Name="Bosnia And Herzegovina", Id = Guid.NewGuid()},
                new Country {Name="Botswana", Id = Guid.NewGuid()},
                new Country {Name="Bouvet Island", Id = Guid.NewGuid()},
                new Country {Name="Brazil", Id = Guid.NewGuid()},
                new Country {Name="British Indian Ocean Territory", Id = Guid.NewGuid()},
                new Country {Name="Brunei Darussalam", Id = Guid.NewGuid()},
                new Country {Name="Bulgaria", Id = Guid.NewGuid()},
                new Country {Name="Burkina Faso", Id = Guid.NewGuid()},
                new Country {Name="Burundi", Id = Guid.NewGuid()},
                new Country {Name="Cambodia", Id = Guid.NewGuid()},
                new Country {Name="Cameroon", Id = Guid.NewGuid()},
                new Country {Name="Canada", Id = Guid.NewGuid()},
                new Country {Name="Cape Verde", Id = Guid.NewGuid()},
                new Country {Name="Cayman Islands", Id = Guid.NewGuid()},
                new Country {Name="Central African Republic", Id = Guid.NewGuid()},
                new Country {Name="Chad", Id = Guid.NewGuid()},
                new Country {Name="Chile", Id = Guid.NewGuid()},
                new Country {Name="China", Id = Guid.NewGuid()},
                new Country {Name="Christmas Island", Id = Guid.NewGuid()},
                new Country {Name="Cocos (keeling) Islands", Id = Guid.NewGuid()},
                new Country {Name="Colombia", Id = Guid.NewGuid()},
                new Country {Name="Comoros", Id = Guid.NewGuid()},
                new Country {Name="Congo", Id = Guid.NewGuid()},
                new Country {Name="Congo, The Democratic Republic Of The", Id = Guid.NewGuid()},
                new Country {Name="Cook Islands", Id = Guid.NewGuid()},
                new Country {Name="Costa Rica", Id = Guid.NewGuid()},
                new Country {Name="Cote D'ivoire", Id = Guid.NewGuid()},
                new Country {Name="Croatia", Id = Guid.NewGuid()},
                new Country {Name="Cuba", Id = Guid.NewGuid()},
                new Country {Name="Cyprus", Id = Guid.NewGuid()},
                new Country {Name="Czech Republic", Id = Guid.NewGuid()},
                new Country {Name="Denmark", Id = Guid.NewGuid()},
                new Country {Name="Djibouti", Id = Guid.NewGuid()},
                new Country {Name="Dominica", Id = Guid.NewGuid()},
                new Country {Name="Dominican Republic", Id = Guid.NewGuid()},
                new Country {Name="East Timor", Id = Guid.NewGuid()},
                new Country {Name="Ecuador", Id = Guid.NewGuid()},
                new Country {Name="Egypt", Id = Guid.NewGuid()},
                new Country {Name="El Salvador", Id = Guid.NewGuid()},
                new Country {Name="Equatorial Guinea", Id = Guid.NewGuid()},
                new Country {Name="Eritrea", Id = Guid.NewGuid()},
                new Country {Name="Estonia", Id = Guid.NewGuid()},
                new Country {Name="Ethiopia", Id = Guid.NewGuid()},
                new Country {Name="Falkland Islands (malvinas)", Id = Guid.NewGuid()},
                new Country {Name="Faroe Islands", Id = Guid.NewGuid()},
                new Country {Name="Fiji", Id = Guid.NewGuid()},
                new Country {Name="Finland", Id = Guid.NewGuid()},
                new Country {Name="France", Id = Guid.NewGuid()},
                new Country {Name="French Guiana", Id = Guid.NewGuid()},
                new Country {Name="French Polynesia", Id = Guid.NewGuid()},
                new Country {Name="French Southern Territories", Id = Guid.NewGuid()},
                new Country {Name="Gabon", Id = Guid.NewGuid()},
                new Country {Name="Gambia", Id = Guid.NewGuid()},
                new Country {Name="Georgia", Id = Guid.NewGuid()},
                new Country {Name="Germany", Id = Guid.NewGuid()},
                new Country {Name="Ghana", Id = Guid.NewGuid()},
                new Country {Name="Gibraltar", Id = Guid.NewGuid()},
                new Country {Name="Greece", Id = Guid.NewGuid()},
                new Country {Name="Greenland", Id = Guid.NewGuid()},
                new Country {Name="Grenada", Id = Guid.NewGuid()},
                new Country {Name="Guadeloupe", Id = Guid.NewGuid()},
                new Country {Name="Guam", Id = Guid.NewGuid()},
                new Country {Name="Guatemala", Id = Guid.NewGuid()},
                new Country {Name="Guinea", Id = Guid.NewGuid()},
                new Country {Name="Guinea-bissau", Id = Guid.NewGuid()},
                new Country {Name="Guyana", Id = Guid.NewGuid()},
                new Country {Name="Haiti", Id = Guid.NewGuid()},
                new Country {Name="Heard Island And Mcdonald Islands", Id = Guid.NewGuid()},
                new Country {Name="Holy See (vatican City State)", Id = Guid.NewGuid()},
                new Country {Name="Honduras", Id = Guid.NewGuid()},
                new Country {Name="Hong Kong", Id = Guid.NewGuid()},
                new Country {Name="Hungary", Id = Guid.NewGuid()},
                new Country {Name="Iceland", Id = Guid.NewGuid()},
                new Country {Name="India", Id = Guid.NewGuid()},
                new Country {Name="Indonesia", Id = Guid.NewGuid()},
                new Country {Name="Iran, Islamic Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Iraq", Id = Guid.NewGuid()},
                new Country {Name="Ireland", Id = Guid.NewGuid()},
                new Country {Name="Israel", Id = Guid.NewGuid()},
                new Country {Name="Italy", Id = Guid.NewGuid()},
                new Country {Name="Jamaica", Id = Guid.NewGuid()},
                new Country {Name="Japan", Id = Guid.NewGuid()},
                new Country {Name="Jordan", Id = Guid.NewGuid()},
                new Country {Name="Kazakstan", Id = Guid.NewGuid()},
                new Country {Name="Kenya", Id = Guid.NewGuid()},
                new Country {Name="Kiribati", Id = Guid.NewGuid()},
                new Country {Name="Korea, Democratic People's Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Korea, Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Kosovo", Id = Guid.NewGuid()},
                new Country {Name="Kuwait", Id = Guid.NewGuid()},
                new Country {Name="Kyrgyzstan", Id = Guid.NewGuid()},
                new Country {Name="Lao People's Democratic Republic", Id = Guid.NewGuid()},
                new Country {Name="Latvia", Id = Guid.NewGuid()},
                new Country {Name="Lebanon", Id = Guid.NewGuid()},
                new Country {Name="Lesotho", Id = Guid.NewGuid()},
                new Country {Name="Liberia", Id = Guid.NewGuid()},
                new Country {Name="Libyan Arab Jamahiriya", Id = Guid.NewGuid()},
                new Country {Name="Liechtenstein", Id = Guid.NewGuid()},
                new Country {Name="Lithuania", Id = Guid.NewGuid()},
                new Country {Name="Luxembourg", Id = Guid.NewGuid()},
                new Country {Name="Macau", Id = Guid.NewGuid()},
                new Country {Name="Macedonia, The Former Yugoslav Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Madagascar", Id = Guid.NewGuid()},
                new Country {Name="Malawi", Id = Guid.NewGuid()},
                new Country {Name="Malaysia", Id = Guid.NewGuid()},
                new Country {Name="Maldives", Id = Guid.NewGuid()},
                new Country {Name="Mali", Id = Guid.NewGuid()},
                new Country {Name="Malta", Id = Guid.NewGuid()},
                new Country {Name="Marshall Islands", Id = Guid.NewGuid()},
                new Country {Name="Martinique", Id = Guid.NewGuid()},
                new Country {Name="Mauritania", Id = Guid.NewGuid()},
                new Country {Name="Mauritius", Id = Guid.NewGuid()},
                new Country {Name="Mayotte", Id = Guid.NewGuid()},
                new Country {Name="Mexico", Id = Guid.NewGuid()},
                new Country {Name="Micronesia, Federated States Of", Id = Guid.NewGuid()},
                new Country {Name="Moldova, Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Monaco", Id = Guid.NewGuid()},
                new Country {Name="Mongolia", Id = Guid.NewGuid()},
                new Country {Name="Montserrat", Id = Guid.NewGuid()},
                new Country {Name="Montenegro", Id = Guid.NewGuid()},
                new Country {Name="Morocco", Id = Guid.NewGuid()},
                new Country {Name="Mozambique", Id = Guid.NewGuid()},
                new Country {Name="Myanmar", Id = Guid.NewGuid()},
                new Country {Name="Namibia", Id = Guid.NewGuid()},
                new Country {Name="Nauru", Id = Guid.NewGuid()},
                new Country {Name="Nepal", Id = Guid.NewGuid()},
                new Country {Name="Netherlands", Id = Guid.NewGuid()},
                new Country {Name="Netherlands Antilles", Id = Guid.NewGuid()},
                new Country {Name="New Caledonia", Id = Guid.NewGuid()},
                new Country {Name="New Zealand", Id = Guid.NewGuid()},
                new Country {Name="Nicaragua", Id = Guid.NewGuid()},
                new Country {Name="Niger", Id = Guid.NewGuid()},
                new Country {Name="Nigeria", Id = Guid.NewGuid()},
                new Country {Name="Niue", Id = Guid.NewGuid()},
                new Country {Name="Norfolk Island", Id = Guid.NewGuid()},
                new Country {Name="Northern Mariana Islands", Id = Guid.NewGuid()},
                new Country {Name="Norway", Id = Guid.NewGuid()},
                new Country {Name="Oman", Id = Guid.NewGuid()},
                new Country {Name="Pakistan", Id = Guid.NewGuid()},
                new Country {Name="Palau", Id = Guid.NewGuid()},
                new Country {Name="Palestinian Territory", Id = Guid.NewGuid()},
                new Country {Name="Panama", Id = Guid.NewGuid()},
                new Country {Name="Papua New Guinea", Id = Guid.NewGuid()},
                new Country {Name="Paraguay", Id = Guid.NewGuid()},
                new Country {Name="Peru", Id = Guid.NewGuid()},
                new Country {Name="Philippines", Id = Guid.NewGuid()},
                new Country {Name="Pitcairn", Id = Guid.NewGuid()},
                new Country {Name="Poland", Id = Guid.NewGuid()},
                new Country {Name="Portugal", Id = Guid.NewGuid()},
                new Country {Name="Puerto Rico", Id = Guid.NewGuid()},
                new Country {Name="Qatar", Id = Guid.NewGuid()},
                new Country {Name="Reunion", Id = Guid.NewGuid()},
                new Country {Name="Romania", Id = Guid.NewGuid()},
                new Country {Name="Russian Federation", Id = Guid.NewGuid()},
                new Country {Name="Rwanda", Id = Guid.NewGuid()},
                new Country {Name="Saint Helena", Id = Guid.NewGuid()},
                new Country {Name="Saint Kitts And Nevis", Id = Guid.NewGuid()},
                new Country {Name="Saint Lucia", Id = Guid.NewGuid()},
                new Country {Name="Saint Pierre And Miquelon", Id = Guid.NewGuid()},
                new Country {Name="Saint Vincent And The Grenadines", Id = Guid.NewGuid()},
                new Country {Name="Samoa", Id = Guid.NewGuid()},
                new Country {Name="San Marino", Id = Guid.NewGuid()},
                new Country {Name="Sao Tome And Principe", Id = Guid.NewGuid()},
                new Country {Name="Saudi Arabia", Id = Guid.NewGuid()},
                new Country {Name="Senegal", Id = Guid.NewGuid()},
                new Country {Name="Serbia", Id = Guid.NewGuid()},
                new Country {Name="Seychelles", Id = Guid.NewGuid()},
                new Country {Name="Sierra Leone", Id = Guid.NewGuid()},
                new Country {Name="Singapore", Id = Guid.NewGuid()},
                new Country {Name="Slovakia", Id = Guid.NewGuid()},
                new Country {Name="Slovenia", Id = Guid.NewGuid()},
                new Country {Name="Solomon Islands", Id = Guid.NewGuid()},
                new Country {Name="Somalia", Id = Guid.NewGuid()},
                new Country {Name="South Africa", Id = Guid.NewGuid()},
                new Country {Name="South Georgia And The South Sandwich Islands", Id = Guid.NewGuid()},
                new Country {Name="Spain", Id = Guid.NewGuid()},
                new Country {Name="Sri Lanka", Id = Guid.NewGuid()},
                new Country {Name="Sudan", Id = Guid.NewGuid()},
                new Country {Name="Suriname", Id = Guid.NewGuid()},
                new Country {Name="Svalbard And Jan Mayen", Id = Guid.NewGuid()},
                new Country {Name="Swaziland", Id = Guid.NewGuid()},
                new Country {Name="Sweden", Id = Guid.NewGuid()},
                new Country {Name="Switzerland", Id = Guid.NewGuid()},
                new Country {Name="Syrian Arab Republic", Id = Guid.NewGuid()},
                new Country {Name="Taiwan, Province Of China", Id = Guid.NewGuid()},
                new Country {Name="Tajikistan", Id = Guid.NewGuid()},
                new Country {Name="Tanzania, United Republic Of", Id = Guid.NewGuid()},
                new Country {Name="Thailand", Id = Guid.NewGuid()},
                new Country {Name="Togo", Id = Guid.NewGuid()},
                new Country {Name="Tokelau", Id = Guid.NewGuid()},
                new Country {Name="Tonga", Id = Guid.NewGuid()},
                new Country {Name="Trinidad And Tobago", Id = Guid.NewGuid()},
                new Country {Name="Tunisia", Id = Guid.NewGuid()},
                new Country {Name="Turkey", Id = Guid.NewGuid()},
                new Country {Name="Turkmenistan", Id = Guid.NewGuid()},
                new Country {Name="Turks And Caicos Islands", Id = Guid.NewGuid()},
                new Country {Name="Tuvalu", Id = Guid.NewGuid()},
                new Country {Name="Uganda", Id = Guid.NewGuid()},
                new Country {Name="Ukraine", Id = Guid.NewGuid()},
                new Country {Name="United Arab Emirates", Id = Guid.NewGuid()},
                new Country {Name="United Kingdom", Id = Guid.NewGuid()},
                new Country {Name="United States", Id = Guid.NewGuid()},
                new Country {Name="United States Minor Outlying Islands", Id = Guid.NewGuid()},
                new Country {Name="Uruguay", Id = Guid.NewGuid()},
                new Country {Name="Uzbekistan", Id = Guid.NewGuid()},
                new Country {Name="Vanuatu", Id = Guid.NewGuid()},
                new Country {Name="Venezuela", Id = Guid.NewGuid()},
                new Country {Name="Viet Nam", Id = Guid.NewGuid()},
                new Country {Name="Virgin Islands, British", Id = Guid.NewGuid()},
                new Country {Name="Virgin Islands, U.s.", Id = Guid.NewGuid()},
                new Country {Name="Wallis And Futuna", Id = Guid.NewGuid()},
                new Country {Name="Western Sahara", Id = Guid.NewGuid()},
                new Country {Name="Yemen", Id = Guid.NewGuid()},
                new Country {Name="Zambia", Id = Guid.NewGuid()},
                new Country {Name="Zimbabwe", Id = Guid.NewGuid()}
            };

            countries.ForEach(a => countryRepository.Add(a));
            countryRepository.Save();
            #endregion

            #region Ratings

            var ratingRepository = new RatingRepository();

            var ratings = new List<Rating> {
                new Rating{
                    Id          = Guid.NewGuid(),
                    Name        = "High Risk",
                    Description = "Extreme Risk",
                    Color       = "#FF0000"
                },
                new Rating{
                    Id          = Guid.NewGuid(),
                    Name        = "Moderate",
                    Description = "Mid or Moderate Risk",
                    Color       = "#FFA500"
                },
                new Rating{
                    Id          = Guid.NewGuid(),
                    Name        = "Low Risk",
                    Description = "Low risk",
                    Color       = "#FFFF00"
                },
                new Rating{
                    Id          = Guid.NewGuid(),
                    Name        = "Opportunity",
                    Description = "Opportunity or Strength",
                    Color       = "#00FF00"
                },
            };

            ratings.ForEach(a => ratingRepository.Add(a));
            ratingRepository.Save();

            #endregion

            #region Levels

            var levelId1 = Guid.NewGuid();
            var levelId2 = Guid.NewGuid();
            var levelId3 = Guid.NewGuid();
            var levelId4 = Guid.NewGuid();
            var levelId5 = Guid.NewGuid();

            var levelRepository = new LevelRepository();

            var levels = new List<Level> {
                new Level{
                    Id          = levelId1,
                    Name        = "Level 1",
                    Order       = 5
                },
                new Level{
                    Id          = levelId2,
                    Name        = "Level 2",
                    Order       = 4

                },
                new Level{
                    Id          = levelId3,
                    Name        = "Level 3",
                    Order       = 3
                },
                new Level{
                    Id          = levelId4,
                    Name        = "Level 4",
                    Order       = 2
                },
                new Level{
                    Id          = levelId5,
                    Name        = "Level 5",
                    Order       = 1
                },
            };

            levels.ForEach(a => levelRepository.Add(a));
            levelRepository.Save();

            #endregion

            #region Position


            var positionRepository = new PositionRepository();

            var positions = new List<Position> {
                new Position{
                    Id          = Guid.NewGuid(),
                    Name        = "HR Manager",
                    Description = "HR Manager"
                },
                new Position{
                    Id          = Guid.NewGuid(),
                    Name        = "President",
                    Description = "President"
                },
                new Position{
                    Id          = Guid.NewGuid(),
                    Name        = "Product Software Manager",
                    Description = "Product Software Manager"
                },
                new Position{
                    Id          = Guid.NewGuid(),
                    Name        = "Software QA",
                    Description = "Software QA"
                },
                new Position{
                    Id          = Guid.NewGuid(),
                    Name        = "Sales Officer",
                    Description = "Sales Officer"
                },
            };

            positions.ForEach(a => positionRepository.Add(a));
            positionRepository.Save();

            #endregion

            #region Division

            var divisionId1 = Guid.NewGuid();
            var divisionId2 = Guid.NewGuid();
            var divisionId3 = Guid.NewGuid();

            var divisionRepository = new DivisionRepository();

            var divisions = new List<Division> {
                new Division{
                    Id          = divisionId1,
                    Name        = "Executive Office",
                    Description = "Executive Office"
                },
                new Division{
                    Id          = divisionId2,
                    Name        = "Software Development",
                    Description = "Software Development"
                },
                new Division{
                    Id          = divisionId3,
                    Name        = "Admininstration",
                    Description = "Admininstration"

                },
            };

            divisions.ForEach(a => divisionRepository.Add(a));
            divisionRepository.Save();

            #endregion

            #region Competency Types


            var competencyTypeRepository = new CompetencyTypeRepository();

            var competencyTypes = new List<CompetencyType> {
                new CompetencyType{
                    Id          = Guid.NewGuid(),
                    Name        = "Logical",
                    Description = "Logical thinkers observe and analyze phenomena, reactions, and feedback and then draw conclusions based on that input. They can justify their strategies, actions, and decisions based on the facts they gather."

                },
                new CompetencyType{
                    Id          = Guid.NewGuid(),
                    Name        = "Behavioural",
                    Description = "Strengths in a business setting"

                },
                new CompetencyType{
                    Id          = Guid.NewGuid(),
                    Name        = "Technical",
                    Description = "Knowledge or skill that is useful in a particular industry"

                },
            };

            competencyTypes.ForEach(a => competencyTypeRepository.Add(a));
            competencyTypeRepository.Save();

            #endregion

            #region IssueCategories


            var issueCategoryRepository = new IssueCategoryRepository();

            var issueCategorys = new List<IssueCategory> {
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "General",
                    Description     = "General"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Economical",
                    Description     = "Economical"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Environmental",
                    Description     = "Environmental"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Weakness",
                    Description     = "Weakness"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Opportunity",
                    Description     = "Opportunity"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Threat",
                    Description     = "Threat"
                },
                new IssueCategory{
                    Id              = Guid.NewGuid(),
                    Name            = "Hazard",
                    Description     = "Hazard"
                },
            };

            issueCategorys.ForEach(a => issueCategoryRepository.Add(a));
            issueCategoryRepository.Save();

            #endregion

            #region Document Categories

            var documentCategoryId1 = Guid.NewGuid();
            var documentCategoryId2 = Guid.NewGuid();
            var documentCategoryId3 = Guid.NewGuid();

            var documentCategoryRepository = new DocumentCategoryRepository();

            var documentCategorys = new List<DocumentCategory> {
                new DocumentCategory{
                    Id          = documentCategoryId1,
                    Name        = "Assessment",
                    LevelId     = levelId1,
                    LevelName   = "Level 1",
                    Description = "Assessment Description"

                },
                new DocumentCategory{
                    Id          = documentCategoryId2,
                    Name        = "Procedure",
                    LevelId     = levelId3,
                    LevelName   = "Level 3",
                    Description = "Procedure Description"

                },
                new DocumentCategory{
                    Id          = documentCategoryId3,
                    Name        = "Guidelines",
                    LevelId     = levelId4,
                    LevelName   = "Level 4",
                    Description = "Guidelines Description"

                },
            };

            documentCategorys.ForEach(a => documentCategoryRepository.Add(a));
            documentCategoryRepository.Save();

            #endregion

            #region DocumentTypes


            var documentGroupRepository = new DocumentGroupRepository();

            var documentGroups = new List<DocumentGroup> {
                new DocumentGroup{
                    Id                      = Guid.NewGuid(),
                    Name                    = "Supporting Documents",
                    Description             = "Supporting Documents",
                    DocumentCategoryId      = documentCategoryId1,
                    DocumentCategoryName    = "Assessment",
                    DocumentTypePrefix      = "SD"
                },
                new DocumentGroup{
                    Id                      = Guid.NewGuid(),
                    Name                    = "Quality Manual",
                    Description             = "Quality Manual",
                    DocumentCategoryId      = documentCategoryId2,
                    DocumentCategoryName    = "Procedure",
                    DocumentTypePrefix      = "QM"
                },
                new DocumentGroup{
                    Id                      = Guid.NewGuid(),
                    Name                    = "Procedures",
                    Description             = "Quality Procedures",
                    DocumentCategoryId      = documentCategoryId3,
                    DocumentCategoryName    = "Guidelines",
                    DocumentTypePrefix      = "QPD"
                },
                new DocumentGroup{
                    Id                      = Guid.NewGuid(),
                    Name                    = "Quality Policy",
                    Description             = "Quality Policy is simply a general statement of the organization’s commitment to quality.",
                    DocumentCategoryId      = documentCategoryId1,
                    DocumentCategoryName    = "Assessment",
                    DocumentTypePrefix      = "QPL"
                },
            };

            documentGroups.ForEach(a => documentGroupRepository.Add(a));
            documentGroupRepository.Save();


            #endregion

            #region Employees


            var employeeId1  = Guid.NewGuid();
            var employeeId2  = Guid.NewGuid();
            var employeeId3  = Guid.NewGuid();
            var employeeId4  = Guid.NewGuid();
            var employeeId5  = Guid.NewGuid();
            var employeeId6  = Guid.NewGuid();
            var employeeId7  = Guid.NewGuid();
            var employeeId8  = Guid.NewGuid();
            var employeeId9  = Guid.NewGuid();
            var employeeId10 = Guid.NewGuid();
            var employeeId11 = Guid.NewGuid();
            var employeeId12 = Guid.NewGuid();
            var employeeId13 = Guid.NewGuid();
            var employeeId14 = Guid.NewGuid();
            var employeeId15 = Guid.NewGuid();
            var employeeId16 = Guid.NewGuid();
            var employeeId17 = Guid.NewGuid();
            var employeeId18 = Guid.NewGuid();
            var employeeId19 = Guid.NewGuid();
            var employeeId20 = Guid.NewGuid();
            var employeeId21 = Guid.NewGuid();
            var employeeId22 = Guid.NewGuid();
            var employeeId23 = Guid.NewGuid();

            var employeeRepository = new EmployeeRepository();

            var employees = new List<Employee> {
                new Employee{
                    Id          = employeeId1,
                    Nationality = "Filipino",
                    Firstname   = "Dana",
                    Middlename  = "R",
                    Lastname    = "Pruitt",
                    Fullname    = "Dana R. Pruitt",
                    Address     = "4585 Zimmerman Lane Los Angeles, CA 90026",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user4
                },
                new Employee{
                    Id          = employeeId2,
                    Nationality = "Filipino",
                    Firstname   = "Bianca",
                    Middlename  = "Gomes",
                    Lastname    = "Melo",
                    Fullname    = "Bianca Gomez Melo",
                    Address     = "4507 Oakwood Avenue Manhattan, NY 10016",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user5b

                },
                new Employee{
                    Id          = employeeId3,
                    Nationality = "Filipino",
                    Firstname   = "Isabela",
                    Middlename  = "Pereira",
                    Lastname    = "Carvalho",
                    Fullname    = "Isabela Pereira Carvalho",
                    Address     = "4210 Union Street Seattle, WA 98109",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user6
                },
                new Employee{
                    Id          = employeeId4,
                    Nationality = "Filipino",
                    Firstname   = "Moyra",
                    Middlename  = "Chadderton",
                    Lastname    = "Balazs",
                    Fullname    = "Moyra Chadderton Balazs",
                    Address     = "1482 Mcbride Court",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user7
                },
                new Employee{
                    Id          = employeeId5,
                    Nationality = "Filipino",
                    Firstname   = "Archaimbaud",
                    Middlename  = "McGeady",
                    Lastname    = "Layborn",
                    Fullname    = "Archaimbaud McGeady Layborn",
                    Address     = "3 Swallow Alley",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user8
                },
                new Employee{
                    Id          = employeeId6,
                    Nationality = "Filipino",
                    Firstname   = "Yoshiko",
                    Middlename  = "Hachard",
                    Lastname    = "Hicken",
                    Fullname    = "Yoshiko Hachard Hicken",
                    Address     = "55 Duke Crossing",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user9
                },
                new Employee{
                    Id          = employeeId7,
                    Nationality = "Filipino",
                    Firstname   = "Gifford",
                    Middlename  = "Templman",
                    Lastname    = "Treslove",
                    Fullname    = "Gifford Templman Treslove",
                    Address     = "6735 Kensington Plaza",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user10
                },
                new Employee{
                    Id          = employeeId8,
                    Nationality = "Filipino",
                    Firstname   = "Kalie",
                    Middlename  = "Windebank",
                    Lastname    = "Gon",
                    Fullname    = "Kalie Windebank Gon",
                    Address     = "9461 Northport Pass",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user11
                },
                new Employee{
                    Id          = employeeId9,
                    Nationality = "Filipino",
                    Firstname   = "Tiffi",
                    Middlename  = "Cale",
                    Lastname    = "Bruty",
                    Fullname    = "Tiffi Cale Bruty",
                    Address     = "06 Holy Cross Alley",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user12
                },
                new Employee{
                    Id          = employeeId10,
                    Nationality = "Filipino",
                    Firstname   = "Stefano",
                    Middlename  = "Canelas",
                    Lastname    = "Creany",
                    Fullname    = "Stefano Canelas Creany",
                    Address     = "7 Golf Way",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user13
                },
                new Employee{
                    Id          = employeeId11,
                    Nationality = "Filipino",
                    Firstname   = "Jervis",
                    Middlename  = "Loxly",
                    Lastname    = "Mountford",
                    Fullname    = "Jervis Loxly Mountford",
                    Address     = "65 Sachs Pass",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user14
                },
                new Employee{
                    Id          = employeeId12,
                    Nationality = "Filipino",
                    Firstname   = "Anya",
                    Middlename  = "Sloper",
                    Lastname    = "Coey",
                    Fullname    = "Anya Sloper Coey",
                    Address     = "0583 Doe Crossing Road",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user15
                },
                new Employee{
                    Id          = employeeId13,
                    Nationality = "Filipino",
                    Firstname   = "Francklyn",
                    Middlename  = "Haversham",
                    Lastname    = "Gerbel",
                    Fullname    = "Francklyn Haversham Gerbel",
                    Address     = "0 Raven Hill",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user16
                },
                new Employee{
                    Id          = employeeId14,
                    Nationality = "Filipino",
                    Firstname   = "Christiana",
                    Middlename  = "Bitten",
                    Lastname    = "Gerbel",
                    Fullname    = "Christiana Bitten Dobrowolski",
                    Address     = "12348 Stephen Trail",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user17
                },
                new Employee{
                    Id          = employeeId15,
                    Nationality = "Filipino",
                    Firstname   = "Webb",
                    Middlename  = "Ashley",
                    Lastname    = "Rue",
                    Fullname    = "Webb Ashley Rue",
                    Address     = "8497 Oxford Place",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user18
                },
                new Employee{
                    Id          = employeeId16,
                    Nationality = "Filipino",
                    Firstname   = "Gerome",
                    Middlename  = "Luckey",
                    Lastname    = "Ionnidis",
                    Fullname    = "Gerome Luckey Ionnidis",
                    Address     = "1 Annamark Point",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user19
                },
                new Employee{
                    Id          = employeeId17,
                    Nationality = "Filipino",
                    Firstname   = "Elwin",
                    Middlename  = "deKnevet",
                    Lastname    = "Castelow",
                    Fullname    = "Elwin LuckedeKnevety Castelow",
                    Address     = "1 Hazelcrest Lane",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user20
                },
                new Employee{
                    Id          = employeeId18,
                    Nationality = "Filipino",
                    Firstname   = "Darby",
                    Middlename  = "Eads",
                    Lastname    = "Hasty",
                    Fullname    = "Darby Eads Hasty",
                    Address     = "9 Lindbergh Terrace",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user21
                },
                new Employee{
                    Id          = employeeId19,
                    Nationality = "Filipino",
                    Firstname   = "Rowland",
                    Middlename  = "Petrosian",
                    Lastname    = "Halls",
                    Fullname    = "Rowland Petrosian Halls",
                    Address     = "192 Raven Hill",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Female",
                    Tag         = EmployeeState.Active,
                    UserId      = user22
                },
                new Employee{
                    Id          = employeeId20,
                    Nationality = "Filipino",
                    Firstname   = "Tedmund",
                    Middlename  = "Scoon",
                    Lastname    = "Groombridge",
                    Fullname    = "Tedmund Scoon Groombridge",
                    Address     = "3 Ridgeway Place",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user23
                },
                new Employee{
                    Id          = employeeId21,
                    Nationality = "Filipino",
                    Firstname   = "Emerson",
                    Middlename  = "Ruiz",
                    Lastname    = "Cristobal",
                    Fullname    = "Emerson Ruiz Cristobal",
                    Address     = "#2-17th St. EBB",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user1
                },
                new Employee{
                    Id          = employeeId22,
                    Nationality = "Filipino",
                    Firstname   = "Edison",
                    Middlename  = "Yap",
                    Lastname    = "Pike",
                    Fullname    = "Edison Pike",
                    Address     = "B3 Lot 97 Ostini St., Camella Milan, San Pedro Laguna",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user3
                },
                new Employee{
                    Id          = employeeId23,
                    Nationality = "Filipino",
                    Firstname   = "John",
                    Middlename  = "Magdaong",
                    Lastname    = "Ramboyong",
                    Fullname    = "John Ramboyong",
                    Address     = "San Pedro Laguna",
                    DateOfBirth = DateTime.Now.AddDays(-5).AddYears(20),
                    Gender      = "Male",
                    Tag         = EmployeeState.Active,
                    UserId      = user2
                },
            };

            employees.ForEach(a => employeeRepository.Add(a));
            employeeRepository.Save();
            #endregion

            #region DocumentQualification

            var documentQualificationRepository = new DocumentQualificationRepository();

            var documentQualifications = new List<DocumentQualification> {
                new DocumentQualification{
                    Id          = Guid.NewGuid(),
                    Name        = "Qualification One",
                    Description = "Q1 Description"
                },
                new DocumentQualification{
                    Id          = Guid.NewGuid(),
                    Name        = "Qualification Two",
                    Description = "Q2 Description"
                },
                new DocumentQualification{
                    Id          = Guid.NewGuid(),
                    Name        = "Qualification Three",
                    Description = "Q3 Description"
                },
            };

            documentQualifications.ForEach(a => documentQualificationRepository.Add(a));
            documentQualificationRepository.Save();
            #endregion

            #region DocumentSection
            var documentSectionRepository = new DocumentSectionRepository();

            var documentSections = new List<DocumentSection> {
                new DocumentSection{
                    Id          = Guid.NewGuid(),
                    Name        = "Section One",
                    Description = "S1 Description"
                },
                new DocumentSection{
                    Id          = Guid.NewGuid(),
                    Name        = "Section Two",
                    Description = "S2 Description"
                },
                new DocumentSection{
                    Id          = Guid.NewGuid(),
                    Name        = "Section Three",
                    Description = "S3 Description"
                },
            };

            documentSections.ForEach(a => documentSectionRepository.Add(a));
            documentSectionRepository.Save();

            #endregion

            #region Departments


            var departmentRepository = new DepartmentRepository();

            var departments = new List<Department> {
                new Department{
                    Id              = Guid.NewGuid(),
                    Code            = "AD01",
                    Name            = "Administration Department",
                    Description     = "The Administration Department provides administrative and technical support in the areas of human resources (HR), budgetary, strategic planning, legal affairs, calls for tenders, facilities and security.",
                    ProcessCode     = "ADC",
                    DivisionId      = divisionId1,
                    DivisionName    = "Executive Office",
                    LevelId         = levelId1,
                    LevelName       = "Level 1",
                    HeadId          = employeeId1,
                    HeadName        = "Dana R. Pruitt"
                },
                new Department{
                    Id          = Guid.NewGuid(),
                    Code            = "AF02",
                    Name            = "Accounting and Finance",
                    Description     = "The accounting department handles the bookkeeping for a business during the fiscal year. All revenue, expenses and company equity are tracked by the accounting department and reported to the Internal Revenue Service at the end of the company's fiscal year",
                    ProcessCode     = "AFC",
                    DivisionId      = divisionId2,
                    DivisionName    = "Software Development",
                    LevelId         = levelId2,
                    LevelName       = "Level 2",
                    HeadId          = employeeId3,
                    HeadName        = "Isabela Pereira Carvalho"

                },
                new Department{
                    Id          = Guid.NewGuid(),
                    Code            = "MA03",
                    Name            = "Marketing and Advertising",
                    Description     = "The marketing and advertising department for a business is responsible for developing product packaging, pricing, and creative materials for informing potential customers of the company's offerings",
                    ProcessCode     = "MAC",
                    DivisionId      = divisionId3,
                    DivisionName    = "Admininstration",
                    LevelId         = levelId2,
                    LevelName       = "Level 2",
                    HeadId          = employeeId3,
                    HeadName        = "Isabela Pereira Carvalho"
                },
                new Department{
                    Id          = Guid.NewGuid(),
                    Code            = "PI04",
                    Name            = "Production and Inventory",
                    Description     = "The production department orders inventory for production when needed, fulfills production orders specified by management and coordinates with the marketing and advertising department to make changes to products",
                    ProcessCode     = "PIC",
                    DivisionId      = divisionId3,
                    DivisionName    = "Admininstration",
                    LevelId         = levelId5,
                    LevelName       = "Level 5",
                    HeadId          = employeeId6,
                    HeadName        = "Yoshiko Hachard Hicken"
                },
                new Department{
                    Id          = Guid.NewGuid(),
                    Code            = "SD05",
                    Name            = "Sales Department",
                    Description     = "Sales departments are needed in companies that sell retail or wholesale items to other businesses or consumers. Sales departments coordinate their sales force to build customer relationships, meet particular revenue goals and pitch new products. The sales force may use a push or a pull method for attracting customers.",
                    ProcessCode     = "SDC",
                    DivisionId      = divisionId3,
                    DivisionName    = "Admininstration",
                    LevelId         = levelId5,
                    LevelName       = "Level 6",
                    HeadId          = employeeId8,
                    HeadName        = "Kalie Windebank Gon"
                },
            };

            departments.ForEach(a => departmentRepository.Add(a));
            departmentRepository.Save();

            #endregion

            #region Document Classification

            var documentClassificationRepository = new DocumentClassificationRepository();

            var documentClassficiations = new List<DocumentClassification> {
                new DocumentClassification{
                    Id              = Guid.NewGuid(),
                    Name            = "Level 1",
                    Description     = "Level 1"
                },
                new DocumentClassification{
                    Id              = Guid.NewGuid(),
                    Name            = "Level 2",
                    Description     = "Level 2"
                },
                new DocumentClassification{
                    Id              = Guid.NewGuid(),
                    Name            = "Level 3",
                    Description     = "Level 3"
                },
                new DocumentClassification{
                    Id              = Guid.NewGuid(),
                    Name            = "Level 4",
                    Description     = "Level 4"
                },
                new DocumentClassification{
                    Id              = Guid.NewGuid(),
                    Name            = "Level 5",
                    Description     = "Level 5"
                },
            };

            documentClassficiations.ForEach(a => documentClassificationRepository.Add(a));
            documentClassificationRepository.Save();

            #endregion
        }
    }
}
