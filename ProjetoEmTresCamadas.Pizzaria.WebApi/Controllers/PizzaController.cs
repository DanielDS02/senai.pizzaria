﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Entidades;
using ProjetoEmTresCamadas.Pizzaria.RegraDeNegocio.Regras;

namespace ProjetoEmTresCamadas.Pizzaria.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public ILogger<PizzaController> Logger { get; }

    public PizzaController(
        IPizzaService pizzaService,
        ILogger<PizzaController> logger)
    {
        _pizzaService = pizzaService;
        Logger = logger;
    }

    [HttpGet]
    public async Task<Pizza[]> GetPizzas()
    {
        Logger.LogInformation("Buscando as pizzas");
        List<Pizza> pizzas = await _pizzaService.ObterTodos();
        Logger.LogDebug("Possui {0} pizzas", pizzas.Count);

        return pizzas.ToArray();
    }

    [HttpGet("{id}")]
    public async Task<Pizza> GetPizza(int id)
    {
        Logger.LogInformation("Buscando as pizzas");
        Pizza pizza = await _pizzaService.Obter(id);
        Logger.LogDebug("Possui {0} pizza", pizza);

        return pizza;
    }

    [HttpPost]
    public Pizza CriarPizza(Pizza pizza)
    {
        Logger.LogInformation("Criando pizza");
        Logger.LogDebug("Dados da pizza a ser criada {0}", pizza);
        pizza = _pizzaService.Adicionar(pizza);

        return pizza;
    }

    [HttpPut]
    public async Task<Pizza> AtualizarPizza(Pizza pizza)
    {
        Logger.LogInformation("Atualizando a pizza");
        Logger.LogDebug("Dados da pizza a ser criada {0}", pizza);
        return await _pizzaService.AtualizarAsync(pizza); 
    }

    [HttpDelete]
    public async Task DeletePizza(int ID)
    {
        Logger.LogInformation("Deletando a pizza");
        Logger.LogDebug("Dados da pizza a ser deletada {0}", ID);
        await _pizzaService.Deletar(ID);
    }

}
