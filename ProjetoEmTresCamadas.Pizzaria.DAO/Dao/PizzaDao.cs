﻿using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using ProjetoEmTresCamadas.Pizzaria.DAO.Settings;
using ProjetoEmTresCamadas.Pizzaria.DAO.ValueObjects;

namespace ProjetoEmTresCamadas.Pizzaria.DAO.Dao;
public class PizzaDao : BaseDao<PizzaVo>, IPizzaDao
{
    private const string TABELA_PIZZA_NOME = "TB_PIZZA";

    private const string TABELA_PIZZA = @$"CREATE TABLE IF NOT EXISTS {TABELA_PIZZA_NOME}
                (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Sabor VARCHAR(50) not null,
                    Descricao VARCHAR(100),
                    TamanhoDePizza INTEGER,
                    Valor REAL
                )";

    private const string INSERIR_PIZZA = @$"
                INSERT INTO {TABELA_PIZZA_NOME} (Sabor, Descricao, TamanhoDePizza, Valor)
                VALUES (@Sabor, @Descricao, @TamanhoDePizza, @Valor)";

    private const string UPDATE_PIZZA = @$"
    UPDATE {TABELA_PIZZA_NOME}
    SET
        Sabor = @Sabor,
        Descricao = @Descricao,
        TamanhoDePizza = @TamanhoDePizza,
        Valor = @Valor
    WHERE
        ID = @Id";

    private const string DELETE_PIZZA = $@"
    DELETE FROM {TABELA_PIZZA_NOME} 
    WHERE ID = @ID";

    private const string SELECT_PIZZA = @$"SELECT * FROM {TABELA_PIZZA_NOME}";
    private const string SELECT_PIZZA_BY_ID = @$"SELECT * FROM {TABELA_PIZZA_NOME} WHERE ID = @ID";

    public PizzaDao(IOptions<ConnectionStrings> connectionStringOptions) : base(
        TABELA_PIZZA,
        SELECT_PIZZA,
        INSERIR_PIZZA,
        TABELA_PIZZA_NOME,
        UPDATE_PIZZA,
        DELETE_PIZZA,
        SELECT_PIZZA_BY_ID,
        connectionStringOptions)
    { }

    protected override PizzaVo CriarInstancia(SqliteDataReader sqliteDataReader)
    {
        return new PizzaVo
        {
            Id = Convert.ToInt32(sqliteDataReader["Id"]),
            Sabor = sqliteDataReader["Sabor"].ToString(),
            Descricao = sqliteDataReader["Descricao"].ToString(),
            TamanhoDePizza = Convert.ToInt32(sqliteDataReader["TamanhoDePizza"]),
            Valor = Convert.ToDouble(sqliteDataReader["Valor"])
        };
    }
}
