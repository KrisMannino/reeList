app.service("angularService", function ($http) {


    //get All Eployee
    this.getMovies = function () {
        return $http.get("/api/HomeApi");
    };


    // get Movie By Id
    this.getMovie = function (movieID) {
        return response = $http.get("/api/HomeApi/" + movieID);

    }


    // Update Movie 
    this.updateMov = function (movieID, movie) {
        var response = $http({
            method: "put",
            url: "/api/HomeApi/" + movieID,
            data: JSON.stringify(movie),
            dataType: "json"
        });
        return response;
    }


    // Add Movie
    this.AddMov = function (movie) {
        var response = $http({
            method: "post",
            url: "/api/HomeApi",
            data: JSON.stringify(movie),
            dataType: "json"
        });
        return response;
    }


    //Delete Movie
    this.DeleteMov = function (movieId) {
        var response = $http({
            method: "delete",
            url: "/api/HomeApi/" + movieId
        });
        return response;
    }
});