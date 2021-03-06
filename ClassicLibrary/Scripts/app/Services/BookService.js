﻿(function () {
    angular.module('LibraryApp')
           .factory('bookService', ['$http', '$q', BookService]);

    function BookService($http, $q) {
        bookService = {};

        function getGenres() {
            var deffered = $q.defer();

            $http.get('api/bookgenre')
                .success(function (response) {
                    deffered.resolve(response);
                })
                .error(function (err) {
                    console.error(err);
                });

            return deffered.promise;
        };

        function saveBook(newBook) {
            var deffered = $q.defer();

            $http.post('api/books', {
                Id: newBook.Id,
                Name: newBook.Name,
                Genre: newBook.Genre,
                Author: newBook.Author,
                Status: newBook.Status,
                Quantity: newBook.Quantity
            })
            .success(function (response) {
                response = 'Book "' + newBook.Name + '" added successfully.'
                deffered.resolve(response);
            })
            .error(function (err) {
                deffered.reject(err)
            });

            return deffered.promise;
        };

        function getBooks() {
            var deffered = $q.defer();

            $http.get('api/books')
                .success(function (response) {
                    deffered.resolve(response);
                })
                .error(function (err) {
                    deffered.reject(response);
                });

            return deffered.promise;
        };

        function getMyBooks() {
            var deffered = $q.defer();

            $http.get('api/MyBooks')
                .success(function (response) {
                    deffered.resolve(response);
                })
                .error(function (err) {
                    deffered.reject(err);
                });

            return deffered.promise;
        };

        bookService.genres = getGenres;
        bookService.save = saveBook;
        bookService.books = getBooks;
        bookService.myBooks = getMyBooks;
        return bookService;
    };
})();