app.controller("myCntrl", function ($scope, angularService) {
    $scope.divMovie = false;
    GetAllMovie();
    //To Get All Records  
    function GetAllMovie() {
        var getData = angularService.getMovies();
        getData.then(function (mov) {
            $scope.movies = mov.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editmovie = function (movie) {
        var getData = angularService.getMovie(movie.Id);
        getData.then(function (mov) {
            $scope.movie = mov.data;
            $scope.movieId = movie.Id;
            $scope.movieTitle = movie.Title;
            $scope.movieYear = movie.Year;
            $scope.movieRated = movie.Rated;
            $scope.Action = "Update";
            $scope.divMovie = true;
        }, function () {
            alert('Error in getting record');
        });
    }

    $scope.AddUpdateMovie = function () {
        var Movie = {
            Title: $scope.movieTitle,
            Year: $scope.movieYear,
            Rated: $scope.movieRated
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Movie.Id = $scope.movieId;
            var getData = angularService.updateMov($scope.movieId, Movie);
            getData.then(function (msg) {
                GetAllMovie();
                alert("Movie Id :- " + msg.data.Id + " is Updated");
                $scope.divMovie = false;
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getData = angularService.AddMov(Movie);
            getData.then(function (msg) {
                GetAllMovie();
                alert("Movie Title :- " + msg.data.Title + " is Added");
                $scope.divMovie = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.AddMovieDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divMovie = true;
    }

    $scope.deleteMovie = function (movie) {
        var getData = angularService.DeleteMov(movie.Id);
        getData.then(function (msg) {
            GetAllMovie();
            alert('Movie Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.movieId = "";
        $scope.movieTitle = "";
        $scope.movieYear = "";
        $scope.movieRated = "";
    }
});