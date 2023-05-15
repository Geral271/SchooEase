﻿using WebAppSchoolEase.Models;
using System.Net.Http.Json;
using System.Text.Json;



namespace WebAppSchoolEase.Services
{
    public class EstudianteService : IEstudianteService 
    {

        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public async Task<List<Estudiante>?> Get()
        {
            var response = await client.GetAsync("api/estudiante");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Estudiante>>(content, options);

        }
        public async Task Add(Estudiante estudiante)
        {
            var response = await client.PostAsync("api/periodoacademico", JsonContent.Create(estudiante));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }



    public interface IEstudianteService
    {
        Task<List<Estudiante>?> Get();
        Task Add(Estudiante estudiante);

    }
}