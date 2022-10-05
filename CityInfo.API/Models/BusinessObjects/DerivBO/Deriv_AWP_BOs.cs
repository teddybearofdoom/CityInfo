using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    /// <summary>
    /// Deriv obj containing Team separated AWP counts
    /// </summary>
    public class Deriv_AWP_BOs
    {
        /// <summary>
        /// plain obj to contain AWP counts registered
        /// </summary>
        public Deriv_AWP_BO deriv_AWP_BO_CT { get; set; }
        public Deriv_AWP_BO deriv_AWP_BO_T { get; set; }
        public int round { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
        public Deriv_AWP_BOs()
        {
            deriv_AWP_BO_CT = new Deriv_AWP_BO();
            deriv_AWP_BO_T = new Deriv_AWP_BO();
        }
    }
}
