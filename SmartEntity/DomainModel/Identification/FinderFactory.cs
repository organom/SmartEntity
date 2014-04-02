﻿using System;
using System.Collections.Generic;
using System.Linq;
using SmartEntity.DomainModel.Mapping.Accessors;
using SmartEntity.Environment.Providers;

namespace SmartEntity.DomainModel.Identification
{
    internal class FinderFactory : IFinderFactory
    {
        /// <summary>
        /// The repository provider.
        /// </summary>
        private readonly IRepositoryFilterExecutorProvider repositoryFilterExecutorProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinderFactory" /> class.
        /// </summary>
        /// <param name="repositoryFilterExecutorProvider">The repository filter executor provider.</param>
        public FinderFactory(IRepositoryFilterExecutorProvider repositoryFilterExecutorProvider)
        {
            this.repositoryFilterExecutorProvider = repositoryFilterExecutorProvider;
        }

        /// <summary>
        /// Creates a new <see cref="IFinder"/> instance.
        /// </summary>
        /// <param name="keyProperties">The key properties.</param>
        /// <returns></returns>
        public IFinder Create(IEnumerable<IPropertyAccessor> keyProperties)
        {
            var entityType = keyProperties.First().DtoType;
            try
            {
                var getFromRepositoryLambda =
                    this.repositoryFilterExecutorProvider.GetFilterExecutor(entityType);
               return new Finder(keyProperties, getFromRepositoryLambda);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Cannot create the finder instance for entity type<{0}>.", entityType), ex);
            }
        }

    }
}