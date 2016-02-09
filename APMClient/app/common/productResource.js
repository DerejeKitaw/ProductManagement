(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource", ["$resource","appSettings","currentUser", productResource])
    function productResource($resource, appSttings, currentUser)
    {
        //return $resource(appSttings.serverPath + "/api/products/:id", null, { 'update': { method: 'put' }});
        //return $resource(appSttings.serverPath + "/api/products/:search");
        return $resource(appSttings.serverPath + "/api/products/:id", null, 
        {'get':{
            headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
        },
         'save':{
             headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
         },
         'update':{
                    method: 'put',
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
         }
        });
    }
    

}());