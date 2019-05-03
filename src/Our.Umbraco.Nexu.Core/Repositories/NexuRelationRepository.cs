﻿namespace Our.Umbraco.Nexu.Core.Repositories
{
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    using global::Umbraco.Core;
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Scoping;

    using NPoco;

    using Our.Umbraco.Nexu.Common.Interfaces.Repositories;
    using Our.Umbraco.Nexu.Common.Models;

    /// <summary>
    /// Represents nexu relation repository.
    /// </summary>
    internal class NexuRelationRepository : IRelationRepository
    {
        /// <summary>
        /// The scope provider.
        /// </summary>
        private readonly IScopeProvider scopeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NexuRelationRepository"/> class.
        /// </summary>
        /// <param name="scopeProvider">
        /// The scope provider.
        /// </param>
        public NexuRelationRepository(IScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider;
        }

        /// <inheritdoc />
        public void PersistRelationsForContentItem(Udi contentItemUdi, IEnumerable<NexuRelation> relations)
        {
            using (var scope = this.scopeProvider.CreateScope())
            {
                var db = scope.Database;

                var deleteSql = new Sql<ISqlContext>(scope.SqlContext);
                deleteSql.From<NexuRelation>().Where<NexuRelation>(x => x.ParentUdi == contentItemUdi.ToString());

                db.Delete<NexuRelation>(deleteSql);

                db.InsertBulk(relations);

                scope.Complete();
            }
        }
    }
}
