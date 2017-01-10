using System;
using System.Collections.Generic;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ProjectFilmLibrary
{
    public class LeesKaart
    {
        private Module m = null;
        private String mFileName;
        /// <summary>
        /// Default constructor. Will instantiate the beidpkcs11.dll pkcs11 module
        /// </summary>
        public LeesKaart()
        {
            mFileName = "beidpkcs11.dll";
        }
        public LeesKaart(String moduleFileName)
        {
            mFileName = moduleFileName;
        }

        public string GetSlotDescription()
        {
            String slotID;
            if (m == null)
            {
                m = Module.GetInstance(mFileName);
            }
            //initialization now occurs within the getinstance function
            //m.Initialize();
            try
            {
                // Look for slots (cardreaders)
                // GetSlotList(false) will return all cardreaders
                Slot[] slots = m.GetSlotList(false);
                if (slots.Length == 0)
                    slotID = "";
                else
                    slotID = slots[0].SlotInfo.SlotDescription.Trim();
            }
            finally
            {
                //m.Finalize_();
                m.Dispose();
                m = null;
            }
            return slotID;
        }

        public string GetTokenInfoLabel()
        {
            String tokenInfoLabel;
            if (m == null)
            {
                m = Module.GetInstance(mFileName);
            }
            //m.Initialize();
            try
            {
                // Look for slots (cardreaders)
                // GetSlotList(true) will return only the cardreaders with a 
                // token (smart card)
                tokenInfoLabel = m.GetSlotList(true)[0].Token.TokenInfo.Label.Trim();
            }
            finally
            {
                m.Dispose();//m.Finalize_();
                m = null;
            }
            return tokenInfoLabel;

        }

        public string GetSurname()
        {
            return GetData("surname");
        }
        public string GetFirstNames()
        {
            return GetData("firstnames");
        }
        public string GetStreetAndNumber()
        {
            return GetData("address_street_and_number");
        }
        public string GetZipCode()
        {
            return GetData("address_zip");
        }
        public string GetMunicipality()
        {
            return GetData("address_municipality");
        }
        public string GetNationalNumber()
        {
            return GetData("national_number");
        }
        public string GetDateOfBirth()
        {
            return GetData("date_of_birth");
        }
        public string GetCardNumber()
        {
            return GetData("card_number");
        }

        public ImageSource GetPhotoFile()
        {
            var photoFile = GetFile("PHOTO_FILE");
            var photo = new BitmapImage();

            using (var stream = new MemoryStream(photoFile))
            {
                photo.BeginInit();
                photo.CacheOption = BitmapCacheOption.OnLoad;
                photo.StreamSource = stream;
                photo.EndInit();
            }

            return photo;
        }

        //Generische functie voor oproepen van betrokken data
        //Bron:Eid SDK
        public string GetData(String label)
        {
            String value = "";
            if (m == null)
            {
                m = Module.GetInstance(mFileName);
            }
            // pkcs11 module init
            //m.Initialize();
            try
            {
                // Get the first slot (cardreader) with a token
                Slot[] slotlist = m.GetSlotList(true);
                if (slotlist.Length > 0)
                {
                    Slot slot = slotlist[0];

                    Session session = slot.Token.OpenSession(true);

                    // Search for objects
                    // First, define a search template 

                    // "The label attribute of the objects should equal ..."
                    ByteArrayAttribute classAttribute = new ByteArrayAttribute(CKA.CLASS);
                    classAttribute.Value = BitConverter.GetBytes((uint)Net.Sf.Pkcs11.Wrapper.CKO.DATA);


                    ByteArrayAttribute labelAttribute = new ByteArrayAttribute(CKA.LABEL);
                    labelAttribute.Value = System.Text.Encoding.UTF8.GetBytes(label);


                    session.FindObjectsInit(new P11Attribute[] { classAttribute, labelAttribute });
                    P11Object[] foundObjects = session.FindObjects(50);
                    int counter = foundObjects.Length;
                    Data data;
                    while (counter > 0)
                    {
                        //foundObjects[counter-1].ReadAttributes(session);
                        //public static BooleanAttribute ReadAttribute(Session session, uint hObj, BooleanAttribute attr)
                        data = foundObjects[counter - 1] as Data;
                        label = data.Label.ToString();
                        if (label != null)
                            Console.WriteLine(label);
                        if (data.Value.Value != null)
                        {
                            value = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                            Console.WriteLine(value);
                        }
                        counter--;
                    }
                    session.FindObjectsFinal();
                    session.Dispose();
                }
                else
                {
                    Console.WriteLine("Geen kaart gevonden!\n");
                }
            }
            finally
            {
                // pkcs11 finalize
                m.Dispose();//m.Finalize_();
                m = null;
            }
            return value;
        }

        private byte[] GetFile(String Filename)
        {
            byte[] value = null;
            // pkcs11 module init
            if (m == null)
            {
                m = Module.GetInstance(mFileName);
            }
            //m.Initialize();
            try
            {
                // Get the first slot (cardreader) with a token
                Slot[] slotlist = m.GetSlotList(true);
                if (slotlist.Length > 0)
                {
                    Slot slot = slotlist[0];
                    Session session = slot.Token.OpenSession(true);

                    // Search for objects
                    // First, define a search template 

                    // "The label attribute of the objects should equal ..."                
                    ByteArrayAttribute fileLabel = new ByteArrayAttribute(CKA.LABEL);
                    fileLabel.Value = System.Text.Encoding.UTF8.GetBytes(Filename);
                    ByteArrayAttribute fileData = new ByteArrayAttribute(CKA.CLASS);
                    fileData.Value = BitConverter.GetBytes((uint)Net.Sf.Pkcs11.Wrapper.CKO.DATA);
                    session.FindObjectsInit(new P11Attribute[] {
                        fileLabel,fileData
                    });
                    P11Object[] foundObjects = session.FindObjects(1);
                    if (foundObjects.Length != 0)
                    {
                        Data file = foundObjects[0] as Data;
                        value = file.Value.Value;
                    }
                    session.FindObjectsFinal();
                }
                else
                {
                    Console.WriteLine("No card found\n");
                }
            }
            finally
            {
                // pkcs11 finalize
                m.Dispose();//m.Finalize_();
                m = null;
            }
            return value;
        }
    }
}
