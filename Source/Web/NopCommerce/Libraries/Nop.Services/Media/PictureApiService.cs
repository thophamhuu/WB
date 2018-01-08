using Nop.Core;
using Nop.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Media
{
    public partial class PictureApiService : IPictureService
    {
        /// <summary>
        /// Gets the loaded picture binary depending on picture storage settings
        /// </summary>
        /// <param name="picture">Picture</param>
        /// <returns>Picture binary</returns>
        public byte[] LoadPictureBinary(Picture picture)
        {
            return APIHelper.Instance.PostAsync<byte[]>("Media", "LoadPictureBinary", picture);
        }

        /// <summary>
        /// Get picture SEO friendly name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Result</returns>
        public string GetPictureSeName(string name)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("name", name);
            return APIHelper.Instance.GetAsync<string>("Media", "GetPictureSeName", parameters);
        }

        /// <summary>
        /// Gets the default picture URL
        /// </summary>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <returns>Picture URL</returns>
        public string GetDefaultPictureUrl(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("targetSize", targetSize);
            parameters.Add("defaultPictureType", defaultPictureType);
            parameters.Add("storeLocation", storeLocation);
            return APIHelper.Instance.GetAsync<string>("Media", "GetDefaultPictureUrl", parameters);
        }

        /// <summary>
        /// Get a picture URL
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <returns>Picture URL</returns>
        public string GetPictureUrl(int pictureId,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureId", pictureId);
            parameters.Add("targetSize", targetSize);
            parameters.Add("showDefaultPicture", showDefaultPicture);
            parameters.Add("storeLocation", storeLocation);
            parameters.Add("defaultPictureType", defaultPictureType);
            return APIHelper.Instance.GetAsync<string>("Media", "GetPictureUrl", parameters);
        }

        /// <summary>
        /// Get a picture URL
        /// </summary>
        /// <param name="picture">Picture instance</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <param name="storeLocation">Store location URL; null to use determine the current store location automatically</param>
        /// <param name="defaultPictureType">Default picture type</param>
        /// <returns>Picture URL</returns>
        public string GetPictureUrl(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("picture", picture);
            parameters.Add("targetSize", targetSize);
            parameters.Add("showDefaultPicture", showDefaultPicture);
            parameters.Add("storeLocation", storeLocation);
            parameters.Add("defaultPictureType", defaultPictureType);
            return APIHelper.Instance.GetAsync<string>("Media", "GetPictureUrl", parameters);
        }

        /// <summary>
        /// Get a picture local path
        /// </summary>
        /// <param name="picture">Picture instance</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="showDefaultPicture">A value indicating whether the default picture is shown</param>
        /// <returns></returns>
        public string GetThumbLocalPath(Picture picture, int targetSize = 0, bool showDefaultPicture = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("picture", picture);
            parameters.Add("targetSize", targetSize);
            parameters.Add("showDefaultPicture", showDefaultPicture);
            return APIHelper.Instance.GetAsync<string>("Media", "GetThumbLocalPath", parameters);
        }

        /// <summary>
        /// Gets a picture
        /// </summary>
        /// <param name="pictureId">Picture identifier</param>
        /// <returns>Picture</returns>
        public Picture GetPictureById(int pictureId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureId", pictureId);
            return APIHelper.Instance.GetAsync<Picture>("Media", "GetPictureById", parameters);
        }

        /// <summary>
        /// Deletes a picture
        /// </summary>
        /// <param name="picture">Picture</param>
        public void DeletePicture(Picture picture)
        {
            APIHelper.Instance.PostAsync("Media", "DeletePicture", picture);
        }

        /// <summary>
        /// Gets a collection of pictures
        /// </summary>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Items on each page</param>
        /// <returns>Paged list of pictures</returns>
        public IPagedList<Picture> GetPictures(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<Picture>("Media", "GetPictures", parameters);
        }

        /// <summary>
        /// Gets pictures by product identifier
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="recordsToReturn">Number of records to return. 0 if you want to get all items</param>
        /// <returns>Pictures</returns>
        public IList<Picture> GetPicturesByProductId(int productId, int recordsToReturn = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("recordsToReturn", recordsToReturn);
            return APIHelper.Instance.GetListAsync<Picture>("Media", "GetPicturesByProductId", parameters);
        }

        /// <summary>
        /// Inserts a picture
        /// </summary>
        /// <param name="pictureBinary">The picture binary</param>
        /// <param name="mimeType">The picture MIME type</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <param name="altAttribute">"alt" attribute for "img" HTML element</param>
        /// <param name="titleAttribute">"title" attribute for "img" HTML element</param>
        /// <param name="isNew">A value indicating whether the picture is new</param>
        /// <param name="validateBinary">A value indicating whether to validated provided picture binary</param>
        /// <returns>Picture</returns>
        public Picture InsertPicture(byte[] pictureBinary, string mimeType, string seoFilename,
            string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureBinary", pictureBinary);
            parameters.Add("mimeType", mimeType);
            parameters.Add("seoFilename", seoFilename);
            parameters.Add("altAttribute", altAttribute);
            parameters.Add("titleAttribute", titleAttribute);
            parameters.Add("isNew", isNew);
            parameters.Add("validateBinary", validateBinary);
            return APIHelper.Instance.GetAsync<Picture>("Media", "InsertPicture", parameters);
        }

        /// <summary>
        /// Updates the picture
        /// </summary>
        /// <param name="pictureId">The picture identifier</param>
        /// <param name="pictureBinary">The picture binary</param>
        /// <param name="mimeType">The picture MIME type</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <param name="altAttribute">"alt" attribute for "img" HTML element</param>
        /// <param name="titleAttribute">"title" attribute for "img" HTML element</param>
        /// <param name="isNew">A value indicating whether the picture is new</param>
        /// <param name="validateBinary">A value indicating whether to validated provided picture binary</param>
        /// <returns>Picture</returns>
        public Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType,
            string seoFilename, string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureId", pictureId);
            parameters.Add("pictureBinary", pictureBinary);
            parameters.Add("mimeType", mimeType);
            parameters.Add("seoFilename", seoFilename);
            parameters.Add("altAttribute", altAttribute);
            parameters.Add("titleAttribute", titleAttribute);
            parameters.Add("isNew", isNew);
            parameters.Add("validateBinary", validateBinary);
            return APIHelper.Instance.GetAsync<Picture>("Media", "UpdatePicture", parameters);
        }

        /// <summary>
        /// Updates a SEO filename of a picture
        /// </summary>
        /// <param name="pictureId">The picture identifier</param>
        /// <param name="seoFilename">The SEO filename</param>
        /// <returns>Picture</returns>
        public Picture SetSeoFilename(int pictureId, string seoFilename)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureId", pictureId);
            parameters.Add("seoFilename", seoFilename);
            return APIHelper.Instance.GetAsync<Picture>("Media", "SetSeoFilename", parameters);
        }

        /// <summary>
        /// Validates input picture dimensions
        /// </summary>
        /// <param name="pictureBinary">Picture binary</param>
        /// <param name="mimeType">MIME type</param>
        /// <returns>Picture binary or throws an exception</returns>
        public byte[] ValidatePicture(byte[] pictureBinary, string mimeType)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pictureBinary", pictureBinary);
            parameters.Add("mimeType", mimeType);
            return APIHelper.Instance.GetAsync<byte[]>("Media", "ValidatePicture", parameters);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the images should be stored in data base.
        /// </summary>
        public bool StoreInDb
        {
            get
            {
                return APIHelper.Instance.GetAsync<bool>("Media", "StoreInDb", null);
            }
            set
            {

            }
        }

        /// <summary>
        /// Get pictures hashes
        /// </summary>
        /// <param name="picturesIds">Pictures Ids</param>
        /// <returns></returns>
        public IDictionary<int, string> GetPicturesHash(int[] picturesIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("picturesIds", string.Join(",", picturesIds));
            return APIHelper.Instance.GetAsync<IDictionary<int, string>>("Media", "GetPicturesHash", parameters);
        }
    }
}
