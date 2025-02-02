﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using Picking.Lib_Primavera.Model;

namespace Picking.Controllers
{
    public class LocationsController : AuthorizedApiController
    {
        // GET /api/locations/
        public IEnumerable<StorageLocation> Get()
        {
            return _company.ListStorageLocations();
        }

        // GET /api/locations/<type>
        public IEnumerable<string> Get(string type)
        {
            switch (type)
            {
                case "full":
                    return _company.ListStorageLocations()
                        .Where(location => LocationHelper.FromString(location.Location) != null)
                        .Select(location => location.Location);
                default:
                    throw new HttpRequestValidationException(type);
            }
        }

        // GET /api/locations/<id>
        //public StorageLocation Get(string id)
        //{
        //    return _company.GetStorageLocation(id);
        //}
    }
}
