﻿namespace ProjetoEmTresCamadas.Pizzaria.DAO.Regras;

public interface IDao<T>
{
    Task<T> ObterRegistro(int ID);
    List<T> ObterRegistros();
    List<T> ObterRegistros(int ID);
    int CriarRegistro(T objetoVo);

    Task AtualizarRegistro(T objetoParaAtualizar);

    Task DeletarRegistro(int ID);
}
