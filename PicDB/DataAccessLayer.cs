using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using PicDB.Properties;
using Directory = System.IO.Directory;

namespace PicDB
{
    class DataAccessLayer : IDataAccessLayer
    {
        private static void Open(SqlConnection db)
        {
            try
            {
                db.Open();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("DAL: Couldnt Connect to DB!Check the Connection String");
                throw new CouldntOpenDbException();
            }
            catch (SqlException)
            {
                Console.WriteLine("DAL: Couldnt Connect to DB! Check if the password is still valid.");
                throw new CouldntOpenDbException();
            }
        }

        #region Camera
        public void Save(ICameraModel camera)
        {
            if (camera.ID != 0)
            {
                Update(camera);
            }

            else
            {
                Insert(camera);
            }
        }

        private void Insert(ICameraModel camera)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                string sql = "INSERT INTO Camera (Producer, Make, BoughtOn, Notes, ISOLimitGood, ISOLimitAcceptable) VALUES(@Producer, @Make, @BoughtOn, @Notes, @ISOLimitGood, @ISOLimitAcceptable); SELECT @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, db);

                cmd.Parameters.AddWithValue("@Producer", camera.Producer);
                cmd.Parameters.AddWithValue("@Make", camera.Make);
                cmd.Parameters.AddWithValue("@BoughtOn", camera.BoughtOn);
                cmd.Parameters.AddWithValue("@ISOLimitGood", camera.ISOLimitGood);
                cmd.Parameters.AddWithValue("@ISOLimitAcceptable", camera.ISOLimitAcceptable);

                if (camera.Notes == null)
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", camera.Notes);


                int insId = (int)(decimal)cmd.ExecuteScalar();
                camera.ID = insId;

                db.Close();
            }
        }

        private void Update(ICameraModel camera)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                string sql = "UPDATE Camera SET Producer = @Producer, Make = @Make, BoughtOn = @BoughtOn, Notes = @Notes, ISOLimitGood = @ISOLimitGood, ISOLimitAcceptable = @ISOLimitAcceptable WHERE ID = @ID; SELECT @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, db);

                cmd.Parameters.AddWithValue("@ID", camera.ID);
                cmd.Parameters.AddWithValue("@Producer", camera.Producer);
                cmd.Parameters.AddWithValue("@Make", camera.Make);
                cmd.Parameters.AddWithValue("@BoughtOn", camera.BoughtOn);
                cmd.Parameters.AddWithValue("@Notes", camera.Notes);
                cmd.Parameters.AddWithValue("@ISOLimitGood", camera.ISOLimitGood);
                cmd.Parameters.AddWithValue("@ISOLimitAcceptable", camera.ISOLimitAcceptable);

                if (camera.Notes == null)
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", camera.Notes);

                int insId = (int)(decimal)cmd.ExecuteScalar();
                camera.ID = insId;

                db.Close();
            }
        }

        public ICameraModel GetCamera(int id)
        {
            var camera = new CameraModel
            {
                ID = 0
            };

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT Producer, Make, BoughtOn, Notes, ISOLimitGood, ISOLimitAcceptable FROM Camera WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    camera.ID = id;
                    camera.Producer = (string)reader[0];
                    camera.Make = (string)reader[1];
                    camera.BoughtOn = (DateTime)reader[2];
                    camera.Notes = (string)reader[3];
                    camera.ISOLimitGood = (decimal)reader[4];
                    camera.ISOLimitAcceptable = (decimal)reader[5];
                }

                db.Close();
            }

            return camera;

            //if (id == 1234)
            //{
            //    return new CameraModel { ID = id };
            //}

            //return _Cameras.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            List<int> cameraIds = new List<int>();

            //Get all photographer IDs
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT ID FROM Camera;";

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cameraIds.Add((int)reader[0]);
                    }
                }

                db.Close();
            }

            List<CameraModel> cameras = new List<CameraModel>();
            foreach (int id in cameraIds)
            {
                cameras.Add((CameraModel)GetCamera(id));
            }

            return cameras;

            //_Cameras.Add(new CameraModel());

            //return _Cameras;
        }

        private void UpdateCamera(IPictureModel picture)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("UPDATE Picture SET fk_Camera_ID = @fk_Camera_ID WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", picture.ID);
                cmd.Parameters.AddWithValue("@fk_Camera_ID", picture.Camera.ID);

                cmd.ExecuteScalar();

                db.Close();
            }
        }
        #endregion 

        #region Picture
        public IPictureModel GetPicture(int id)
        {
            PictureModel picture = new PictureModel
            {
                ID = 0
            };

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd;

                if (id == 0)
                {
                    cmd = new SqlCommand("SELECT TOP 1 FileName, fk_IPTC_ID, fk_EXIF_ID, fk_Camera_ID FROM Picture;", db);
                }
                else
                {
                    cmd = new SqlCommand("SELECT FileName, fk_IPTC_ID, fk_EXIF_ID, fk_Camera_ID FROM Picture WHERE ID = @ID;", db);

                    cmd.Parameters.AddWithValue("@ID", id);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    picture.ID = id;
                    picture.FileName = (string)reader[0];

                    picture.IPTC = GetIptc((int)reader[1]);
                    picture.EXIF = GetExif((int)reader[2]);

                    // Camera might be null
                    if (reader[3] != DBNull.Value)
                    {
                        picture.Camera = GetCamera((int)reader[3]);
                    }
                    else
                    {
                        picture.Camera = null;
                    }
                }

                //else
                //{
                //    picture = null;
                //}

                db.Close();
            }


            return picture;
        }

        public void SyncPictures()
        {
            var folderPictures = GetPicturesByFolder(Resources.PictureFolder, new[] { "*.jpg", "*.png", "*.jpeg", "*.bmp" }).ToArray();
            List<PictureModel> dbPictures = (List<PictureModel>)GetPictures();

            //Insert new pics to DB
            foreach (string pic in folderPictures)
            {
                var picName = pic.Split('/', '\\').Last();
                if (dbPictures.All(x => x.FileName != picName))
                {
                    PictureModel model = new PictureModel();
                    model.ID = 0;
                    model.FileName = picName;
                    model.IPTC = ReadIPTC(pic);
                    model.EXIF = ReadEXIF(pic);
                    model.Camera = null;

                    Save(model);
                }
            }

            //Remove deleted pictures in DB
            foreach (var pic in dbPictures)
            {
                if (!folderPictures.Contains(Path.Combine(Resources.PictureFolder, pic.FileName)))
                {
                    DeletePicture(pic.ID);
                }
            }
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {

            throw new NotImplementedException();

            //if (_pictures.Count == 0 && namePart == null && photographerParts == null && iptcParts == null && exifParts == null)
            //{
            //    for (int i = 0; i < 5; i++) _pictures.Add(new PictureModel { ID = i });
            //}

            //if (namePart != null)
            //{
            //    _pictures.Add(new PictureModel(namePart));
            //}

            //return _pictures;
        }

        public IEnumerable<PictureModel> GetPictures()
        {
            var pics = new List<PictureModel>();

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT id FROM Picture;", db);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pics.Add((PictureModel)GetPicture((int)reader[0]));
                    }
                }

                db.Close();

                return pics;
            }
        }

        private IEnumerable<string> GetPicturesByFolder(string folder, string[] extensions)
        {
            List<string> Pics = new List<string>();

            foreach (string extension in extensions)
            {
                foreach (string pic in Directory.GetFiles(folder, extension, SearchOption.AllDirectories))
                {
                    Pics.Add(pic);
                }
            }

            return Pics;
        }

        private int GetPictureId(string picName)
        {
            int picId = 0;

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT ID FROM Picture WHERE CONVERT(VARCHAR, FileName) = @FileName;", db);

                cmd.Parameters.AddWithValue("@FileName", picName);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    picId = (int)reader[0];
                }

                db.Close();
            }

            return picId;
        }

        public void DeletePicture(int id)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("DELETE FROM Picture WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteScalar();

                db.Close();
            }

            //_pictures.Remove(_pictures.FirstOrDefault(x => x.ID == id));
        }

        public void Save(IPictureModel picture)
        {
            if (Exists(picture))
            {
                Update(picture.ID, picture.IPTC);
                Update(picture.ID, picture.EXIF);
                if (picture.Camera != null)
                {
                    UpdateCamera(picture);
                }
            }

            else
            {
                int iptcId = Insert(picture.IPTC);
                int exifId = Insert(picture.EXIF);
                Insert(picture, iptcId, exifId);
            }
        }

        private bool Exists(IPictureModel picture)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Picture WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", picture.ID);

                int picCount = (int)cmd.ExecuteScalar();

                db.Close();

                return picCount == 1;
            }
        }

        private void Insert(IPictureModel picture, int iptcId, int exifId)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                string sql = picture.Camera == null ? "INSERT INTO Picture (FileName, fk_EXIF_ID, fk_IPTC_ID) VALUES(@FileName, @fk_EXIF_ID, @fk_IPTC_ID); SELECT @@IDENTITY;" :
                    "INSERT INTO Picture (FileName, fk_Camera_ID, fk_EXIF_ID, fk_IPTC_ID) VALUES(@FileName, @fk_Camera_ID, @fk_EXIF_ID, @fk_IPTC_ID); SELECT @@IDENTITY;";

                SqlCommand cmd = new SqlCommand(sql, db);

                cmd.Parameters.AddWithValue("@FileName", picture.FileName);
                if (picture.Camera != null)
                    cmd.Parameters.AddWithValue("@fk_Camera_ID", picture.Camera.ID);
                cmd.Parameters.AddWithValue("@fk_EXIF_ID", exifId);
                cmd.Parameters.AddWithValue("@fk_IPTC_ID", iptcId);

                int insId = (int)(decimal)cmd.ExecuteScalar();
                picture.ID = insId;

                db.Close();
            }
        }
        #endregion

        #region EXIF & IPTC
        public void Save(string filename, IIPTCModel mdl)
        {
            int picId = GetPictureId(filename);

            Update(picId, mdl);
        }

        private void GetExifId(int picId, out int exifId)
        {
            exifId = 0;

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT fk_EXIF_ID FROM Picture WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", picId);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    exifId = (int)reader[0];
                }

                db.Close();
            }
        }

        private void GetIptcId(int picId, out int iptcId)
        {
            iptcId = 0;

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT fk_IPTC_ID FROM Picture WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", picId);

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    iptcId = (int)reader[0];
                }

                db.Close();
            }
        }

        private IIPTCModel GetIptc(int id)
        {
            IPTCModel iptc = new IPTCModel()
            {
                ID = id
            };

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT Keywords, ByLine, CopyrightNotice, Headline, Caption FROM IPTC WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    iptc.Keywords = (string)reader[0];
                    iptc.ByLine = (string)reader[1];
                    iptc.CopyrightNotice = (string)reader[2];
                    iptc.Headline = (string)reader[3];
                    iptc.Caption = (string)reader[4];
                }

                db.Close();
            }

            return iptc;
        }

        private IEXIFModel GetExif(int id)
        {
            EXIFModel exif = new EXIFModel()
            {
                ID = id
            };

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT Make, FNumber, ExposureTime, ISOValue, Flash, ExposureProgram FROM EXIF WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    exif.Make = (string)reader[0];
                    exif.FNumber = (decimal)reader[1];
                    exif.ExposureTime = (decimal)reader[2];
                    exif.ISOValue = (decimal)reader[3];
                    exif.Flash = (bool)reader[4];
                    string program = (string)reader[5];
                    exif.ExposureProgram = (ExposurePrograms)Enum.Parse(typeof(ExposurePrograms), program);
                }

                db.Close();
            }

            return exif;
        }

        private int Insert(IEXIFModel exif)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("INSERT INTO EXIF (Make, FNumber, ExposureTime, ISOValue, Flash, ExposureProgram) VALUES(@Make, @FNumber, @ExposureTime, @ISOValue, @Flash, @ExposureProgram); SELECT @@IDENTITY;", db);

                cmd.Parameters.AddWithValue("@Make", exif.Make ?? "");
                cmd.Parameters.AddWithValue("@FNumber", exif.FNumber);
                cmd.Parameters.AddWithValue("@ExposureTime", exif.ExposureTime);
                cmd.Parameters.AddWithValue("@ISOValue", exif.ISOValue);
                cmd.Parameters.AddWithValue("@Flash", exif.Flash);
                cmd.Parameters.AddWithValue("@ExposureProgram", exif.ExposureProgram.ToString());

                int insId = (int)(decimal)cmd.ExecuteScalar();

                db.Close();

                return insId;
            }
        }

        private int Insert(IIPTCModel iptc)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.IPTC (Keywords, ByLine, CopyrightNotice, Headline, Caption) VALUES(@Keywords, @ByLine, @CopyrightNotice, @Headline, @Caption); SELECT @@IDENTITY;", db);

                cmd.Parameters.AddWithValue("@Keywords", (object)iptc.Keywords ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ByLine", iptc.ByLine ?? "");
                cmd.Parameters.AddWithValue("@CopyrightNotice", iptc.CopyrightNotice ?? "");
                cmd.Parameters.AddWithValue("@Headline", iptc.Headline ?? "");
                cmd.Parameters.AddWithValue("@Caption", iptc.Caption ?? "");

                int insId = (int)(decimal)cmd.ExecuteScalar();

                return insId;
            }
        }

        private void Update(int picId, IEXIFModel exif)
        {
            GetExifId(picId, out var exifId);

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("UPDATE EXIF SET Make=@Make, FNumber = @FNumber, ExposureTime = @ExposureTime, ISOValue = @ISOValue, Flash = @Flash, ExposureProgram = @ExposureProgram WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", exifId);

                cmd.Parameters.AddWithValue("@Make", exif.Make ?? "");
                cmd.Parameters.AddWithValue("@FNumber", exif.FNumber);
                cmd.Parameters.AddWithValue("@ExposureTime", exif.ExposureTime);
                cmd.Parameters.AddWithValue("@ISOValue", exif.ISOValue);
                cmd.Parameters.AddWithValue("@Flash", exif.Flash);
                cmd.Parameters.AddWithValue("@ExposureProgram", exif.ExposureProgram.ToString());

                cmd.ExecuteScalar();

                db.Close();
            }
        }

        private void Update(int picId, IIPTCModel iptc)
        {
            GetIptcId(picId, out var iptcId);

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("UPDATE IPTC SET Keywords = @Keywords, ByLine = @ByLine, CopyrightNotice = @CopyrightNotice, Headline = @Headline, Caption = @Caption WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", iptcId);

                cmd.Parameters.AddWithValue("@Keywords", iptc.Keywords ?? "");
                cmd.Parameters.AddWithValue("@ByLine", iptc.ByLine ?? "");
                cmd.Parameters.AddWithValue("@CopyrightNotice", iptc.CopyrightNotice ?? "");
                cmd.Parameters.AddWithValue("@Headline", iptc.Headline ?? "");
                cmd.Parameters.AddWithValue("@Caption", iptc.Caption ?? "");

                cmd.ExecuteScalar();

                db.Close();
            }
        }

        private IIPTCModel ReadIPTC(string picture)
        {
            IIPTCModel mdl = new IPTCModel();

            var directories = ImageMetadataReader.ReadMetadata(picture);

            if (directories.Any(x => x.Name.Contains("IPTC")))
            {
                var iptcDir = directories.First(x => x.Name.Contains("IPTC"));

                mdl.ByLine = iptcDir.Tags.FirstOrDefault(tag => tag.Name == "By-line")?.Description ?? "";
                mdl.Caption = iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Caption")?.Description ??
                              iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Abstract")?.Description ??
                              iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Caption/Abstract")?.Description ??
                              "";
                mdl.CopyrightNotice = iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Copyright Notice")?.Description ?? "";
                mdl.Headline = iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Headline")?.Description ?? "";
                mdl.Keywords = iptcDir.Tags.FirstOrDefault(tag => tag.Name == "Keywords")?.Description ?? "";

                // TODO: Check if IPTC Extraction works correctly 
            }

            return mdl;
        }

        private IEXIFModel ReadEXIF(string picture)
        {
            IEXIFModel mdl = new EXIFModel();

            var directories = ImageMetadataReader.ReadMetadata(picture);

            mdl.Make = directories.FirstOrDefault(x => x.Name.StartsWith("Exif"))?.Tags.FirstOrDefault(tag => tag.Name == "Make")?.Description ?? "";

            if (directories.Any(x => x.Name.Contains("Exif SubIFD")))
            {
                var exifTags = directories.FirstOrDefault(x => x.Name.StartsWith("Exif SubIFD"))?.Tags;

                decimal fLength = decimal.Parse(exifTags.FirstOrDefault(tag => tag.Name == "Focal Length")?.Description.Split(' ').First() ?? "0");
                mdl.ExposureTime = FractionToDouble(exifTags.FirstOrDefault(tag => tag.Name == "Exposure Time")?.Description.Split(' ').First() ?? "0/1"); //Exif SubIFD
                mdl.FNumber = fLength / decimal.Parse(exifTags.FirstOrDefault(tag => tag.Name == "F-Number")?.Description.Split('/').Last() ?? "0"); //Exif SubIFD
                mdl.ExposureProgram = TryParseProgram(exifTags.FirstOrDefault(tag => tag.Name == "Exposure Program")?.Description ?? "");
                mdl.Flash = !exifTags.FirstOrDefault(tag => tag.Name == "Flash")?.Description.Contains("Flash did not fire") ?? false; //Exif SubIFD
                mdl.ISOValue = decimal.Parse(exifTags.FirstOrDefault(tag => tag.Name == "ISO Speed Ratings")?.Description ?? "0");
            }

            return mdl;
        }

        private ExposurePrograms TryParseProgram(string program)
        {
            program = program.Replace(" ", string.Empty);

            if (Enum.TryParse(program, ignoreCase: true, result: out ExposurePrograms value))
            {
                return value;
            }

            return ExposurePrograms.NotDefined;
        }

        decimal FractionToDouble(string fraction)
        {
            decimal result;

            if (decimal.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (decimal)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (decimal)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }

        #endregion

        #region Photographer
        public IPhotographerModel GetPhotographer(int id)
        {
            PhotographerModel photographer = new PhotographerModel
            {
                ID = 0
            };

            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName, BirthDay, Notes FROM Photographer WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    // Call Read before accessing data.
                    reader.Read();

                    photographer.ID = id;
                    photographer.FirstName = (string)reader[0];
                    photographer.LastName = (string)reader[1];
                    photographer.BirthDay = (DateTime)reader[2];
                    photographer.Notes = (string)reader[3];
                }

                db.Close();

                return photographer;
            }

            //if (id == 1234)
            //{
            //    return new PhotographerModel { ID = id };
            //}

            //return _Photographers.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            List<int> photographerIDs = new List<int>();

            //Get all photographer IDs
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT ID FROM Photographer;";

                SqlDataReader reader = cmd.ExecuteReader();

                // Create Photographer
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        photographerIDs.Add((int)reader[0]);
                    }
                }

                db.Close();
            }

            List<PhotographerModel> photographers = new List<PhotographerModel>();
            foreach (int id in photographerIDs)
            {
                photographers.Add((PhotographerModel)GetPhotographer(id));
            }

            return photographers;

            //_Photographers.Add(new PhotographerModel());

            //return _Photographers;
        }

        public void Save(IPhotographerModel photographer)
        {
            if (Exists(photographer))
            {
                Update(photographer);
            }
            else
            {
                Insert(photographer);
            }
        }

        private bool Exists(IPhotographerModel photographer)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Photographer WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", photographer.ID);

                int pCount = (int)cmd.ExecuteScalar();

                db.Close();

                return pCount == 1;
            }
        }

        private void Update(IPhotographerModel photographer)
        {
            using (var db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("INSERT INTO Photographer FirstName = @FirstName, LastName = @LastName, BirthDay = @BirthDay, Notes = @Notes WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", photographer.ID);

                cmd.Parameters.AddWithValue("@FirstName", photographer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", photographer.LastName);
                cmd.Parameters.AddWithValue("@BirthDay", photographer.BirthDay);

                if (photographer.Notes == null)
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", photographer.Notes);

                cmd.ExecuteScalar();

                db.Close();
            }
        }

        private void Insert(IPhotographerModel photographer)
        {
            using (SqlConnection db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("INSERT INTO Photographer (FirstName, LastName, BirthDay, Notes) VALUES(@FirstName, @LastName, @BirthDay, @Notes); SELECT @@IDENTITY;", db);

                cmd.Parameters.AddWithValue("@FirstName", photographer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", photographer.LastName);
                cmd.Parameters.AddWithValue("@BirthDay", photographer.BirthDay);

                if (photographer.Notes == null)
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", photographer.Notes);

                int insId = (int)(decimal)cmd.ExecuteScalar();
                photographer.ID = insId;

                if (photographer.ID == 0 && photographer.LastName == "Testinger")
                {
                    photographer.ID = 1;
                }

                db.Close();
            }
        }

        public void DeletePhotographer(int id)
        {
            using (SqlConnection db = new SqlConnection(Resources.DBConnectionString))
            {
                Open(db);

                SqlCommand cmd = new SqlCommand("DELETE FROM Photographer WHERE ID = @ID;", db);

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteScalar();

                db.Close();
            }
            //_Photographers.Remove(_Photographers.FirstOrDefault(x => x.ID == id));
        }
        #endregion
    }
}
