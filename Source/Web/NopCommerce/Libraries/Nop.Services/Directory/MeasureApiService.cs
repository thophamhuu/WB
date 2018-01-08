using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Directory
{
    public partial class MeasureApiService : IMeasureService
    {
        #region Methods

        #region Dimensions

        /// <summary>
        /// Deletes measure dimension
        /// </summary>
        /// <param name="measureDimension">Measure dimension</param>
        public virtual void DeleteMeasureDimension(MeasureDimension measureDimension)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteMeasureDimension", measureDimension);
        }

        /// <summary>
        /// Gets a measure dimension by identifier
        /// </summary>
        /// <param name="measureDimensionId">Measure dimension identifier</param>
        /// <returns>Measure dimension</returns>
        public virtual MeasureDimension GetMeasureDimensionById(int measureDimensionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("measureDimensionId", measureDimensionId);
            return APIHelper.Instance.GetAsync<MeasureDimension>("Directory", "GetMeasureDimensionById", parameters);
        }

        /// <summary>
        /// Gets a measure dimension by system keyword
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Measure dimension</returns>
        public virtual MeasureDimension GetMeasureDimensionBySystemKeyword(string systemKeyword)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemKeyword", systemKeyword);
            return APIHelper.Instance.GetAsync<MeasureDimension>("Directory", "GetMeasureDimensionBySystemKeyword", parameters);
        }

        /// <summary>
        /// Gets all measure dimensions
        /// </summary>
        /// <returns>Measure dimensions</returns>
        public virtual IList<MeasureDimension> GetAllMeasureDimensions()
        {
            return APIHelper.Instance.GetListAsync<MeasureDimension>("Directory", "GetAllMeasureDimensions", null);
        }

        /// <summary>
        /// Inserts a measure dimension
        /// </summary>
        /// <param name="measure">Measure dimension</param>
        public virtual void InsertMeasureDimension(MeasureDimension measure)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertMeasureDimension", measure);
        }

        /// <summary>
        /// Updates the measure dimension
        /// </summary>
        /// <param name="measure">Measure dimension</param>
        public virtual void UpdateMeasureDimension(MeasureDimension measure)
        {
            APIHelper.Instance.PostAsync("Directory", "UpdateMeasureDimension", measure);
        }

        /// <summary>
        /// Converts dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureDimension">Source dimension</param>
        /// <param name="targetMeasureDimension">Target dimension</param>
        /// <param name="round">A value indicating whether a result should be rounded</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertDimension(decimal value,
            MeasureDimension sourceMeasureDimension, MeasureDimension targetMeasureDimension, bool round = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("sourceMeasureDimension", sourceMeasureDimension);
            parameters.Add("targetMeasureDimension", targetMeasureDimension);
            parameters.Add("round", round);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertDimension", parameters);
        }

        /// <summary>
        /// Converts to primary measure dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureDimension">Source dimension</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertToPrimaryMeasureDimension(decimal value,
            MeasureDimension sourceMeasureDimension)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("sourceMeasureDimension", sourceMeasureDimension);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertToPrimaryMeasureDimension", parameters);
        }

        /// <summary>
        /// Converts from primary dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetMeasureDimension">Target dimension</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertFromPrimaryMeasureDimension(decimal value,
            MeasureDimension targetMeasureDimension)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("targetMeasureDimension", targetMeasureDimension);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertFromPrimaryMeasureDimension", parameters);
        }

        #endregion

        #region Weights

        /// <summary>
        /// Deletes measure weight
        /// </summary>
        /// <param name="measureWeight">Measure weight</param>
        public virtual void DeleteMeasureWeight(MeasureWeight measureWeight)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteMeasureWeight", measureWeight);
        }

        /// <summary>
        /// Gets a measure weight by identifier
        /// </summary>
        /// <param name="measureWeightId">Measure weight identifier</param>
        /// <returns>Measure weight</returns>
        public virtual MeasureWeight GetMeasureWeightById(int measureWeightId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("measureWeightId", measureWeightId);
            return APIHelper.Instance.GetAsync<MeasureWeight>("Directory", "GetMeasureWeightById", parameters);
        }

        /// <summary>
        /// Gets a measure weight by system keyword
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Measure weight</returns>
        public virtual MeasureWeight GetMeasureWeightBySystemKeyword(string systemKeyword)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemKeyword", systemKeyword);
            return APIHelper.Instance.GetAsync<MeasureWeight>("Directory", "GetMeasureWeightBySystemKeyword", parameters);
        }

        /// <summary>
        /// Gets all measure weights
        /// </summary>
        /// <returns>Measure weights</returns>
        public virtual IList<MeasureWeight> GetAllMeasureWeights()
        {
            return APIHelper.Instance.GetListAsync<MeasureWeight>("Directory", "GetAllMeasureWeights", null);
        }

        /// <summary>
        /// Inserts a measure weight
        /// </summary>
        /// <param name="measure">Measure weight</param>
        public virtual void InsertMeasureWeight(MeasureWeight measure)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertMeasureWeight", measure);
        }

        /// <summary>
        /// Updates the measure weight
        /// </summary>
        /// <param name="measure">Measure weight</param>
        public virtual void UpdateMeasureWeight(MeasureWeight measure)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertMeasureWeight", measure);
        }

        /// <summary>
        /// Converts weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <param name="round">A value indicating whether a result should be rounded</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertWeight(decimal value,
            MeasureWeight sourceMeasureWeight, MeasureWeight targetMeasureWeight, bool round = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("sourceMeasureWeight", sourceMeasureWeight);
            parameters.Add("targetMeasureWeight", targetMeasureWeight);
            parameters.Add("round", round);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertWeight", parameters);
        }

        /// <summary>
        /// Converts to primary measure weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertToPrimaryMeasureWeight(decimal value, MeasureWeight sourceMeasureWeight)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("sourceMeasureWeight", sourceMeasureWeight);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertToPrimaryMeasureWeight", parameters);
        }

        /// <summary>
        /// Converts from primary weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertFromPrimaryMeasureWeight(decimal value,
            MeasureWeight targetMeasureWeight)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            parameters.Add("targetMeasureWeight", targetMeasureWeight);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertFromPrimaryMeasureWeight", parameters);
        }

        #endregion

        #endregion
    }
}
