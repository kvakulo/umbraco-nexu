﻿namespace Our.Umbraco.Nexu.Common.Models
{
    using System;

    using global::Umbraco.Core;

    using NPoco;

    /// <summary>
    /// Represents a nexu relation
    /// </summary>
    [TableName("Nexu_Relations")]
    internal class NexuRelation
    {
        private Udi udi;

        /// <summary>
        /// Initializes a new instance of the <see cref="NexuRelation"/> class.
        /// </summary>
        public NexuRelation()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the parent udi
        /// </summary>
        public string ParentUdi { get; set; }

        /// <summary>
        /// Gets or sets the child udi
        /// </summary>
        public string ChildUdi { get; set; }

        /// <summary>
        /// Gets or sets the relation type.
        /// </summary>
        public Guid RelationType { get; set; }

        /// <summary>
        /// Gets or sets the property id.
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets the udi.
        /// </summary>
        public Udi Udi
        {
            get
            {
                if (this.udi != null)
                {
                    return this.udi;
                }

                this.udi = new GuidUdi("nexurelation", this.Id);

                return this.udi;
            }
        }
    }
}
