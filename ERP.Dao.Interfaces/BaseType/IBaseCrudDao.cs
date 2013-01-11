#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ERP.Domain.BasicEntity;
using ERP.Domain.Util;

#endregion

namespace ERP.Dao.Interfaces.BaseType
{
    public interface IBaseCrudDao<T> : IBaseDao where T : BaseEntity
    {
        /// <summary>
        /// Retorna a entidade a partir de seu identificador(Id). Case não exista no banco, este método retornará <value>null</value>.
        /// </summary>
        /// <param name="Id">O id à ser consultado no banco de dados.</param>
        /// <returns>A entidade encontrada, podendo ser uma instancia ou o valor nulo caso ela nao exista no banco de dados.</returns>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro Id seja igual a null.</exception>
        T Get(Guid Id);
        
        /// <summary>
        /// Salva uma entidade no banco de dados. Este método alterará por referencia o id da variavel para o valor gerado no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser salva.</param>
        /// <exception cref="DatabaseOperationException">Caso ocorra algum problema a salvar esta entidade.</exception>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro Id seja igual a null.</exception>
        void Save(T entity);

        /// <summary>
        /// Atualiza o valor da entidade no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada.</param>
        /// <exception cref="DatabaseOperationException">Caso ocorra agum problema ao atualiza o valor da entidade.</exception>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro Id seja igual a null.</exception>
        void Update(T entity);

        /// <summary>
        /// Remove a entidade do banco de dados.
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro entity seja igual a null.</exception>
        void Delete(T entity);

        /// <summary>
        /// Verifica se a entidade já existe no banco a partir de sua chave candidata. Caso ela não exista, 
        /// será retornado o valor <value>null</value>.
        /// </summary>
        /// <param name="item">A entidade a ser verificada</param>
        /// <returns>A entidade caso sejá encontrar ou o valor null caso ela não exista no banco.</returns>
        /// <exception cref="ArgumentNullException">Caso o valor a entidade a ser verificada seja igual a <value>null</value>.</exception>
        T VerifyIfAlreadyRegistred(T item);

        /// <summary>
        /// Lista toda a entidade sem nehum criteria de filtro, nem ordenação.
        /// </summary>
        /// <returns>A lista da entidade no banco de dados.</returns>
        IEnumerable<T> FetchAll();

        /// <summary>
        /// Lista a entidade de acordo com a pagina informada.
        /// </summary>
        /// <param name="pageInfo">Os dados de paginação a ser aplicada.</param>
        /// <returns>Os dados da pagina.</returns>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro pageInfo seja igual a <value>null</value>.</exception>
        PaginatedResult<T> FetchAll(PaginatedInfo pageInfo);

        /// <summary>
        /// Lista a entidade apicando o criterio de busca informado.
        /// </summary>
        /// <param name="criterion">o criterio de busca ser aplicado.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Caso o valor do parametro criterion seja igual a <value>null</value>.</exception>
        IEnumerable<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criterion"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Caso o valor dos parametros criterion ou pageInfo sejam igual a <value>null</value>.</exception>
        PaginatedResult<T> FetchByCustomCriteria(Expression<Func<T, bool>> criterion, PaginatedInfo pageInfo);
    }
}