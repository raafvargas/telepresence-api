using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Telepresence.API.Repository.Base
{
    /// <summary>
    /// Base class for DocumentDB Repositories
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class DocumentDbRespository<TDocument> where TDocument : DocumentBase
    {
        private readonly string _primaryKey = "VmbmTHk9i1z9VSAGcmo10njfrSWkV1ViYnyIYxUUS12XKCjUtw3SWcVEqKaqptd2yakSPY54HicbbycaVle7Gw==";
        private readonly string _endpoint = "https://telepresence.documents.azure.com:443/";
        private readonly string _database;
        private readonly string _collection;
        private readonly DocumentClient _client;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="database">Database name</param>
        /// <param name="collection">Collection name</param>
        public DocumentDbRespository(string database, string collection)
        {
            _database = database;
            _collection = collection;
            _client = new DocumentClient(new Uri(_endpoint), _primaryKey);
        }

        /// <summary>
        /// Save a document
        /// </summary>
        /// <param name="document">The document</param>
        /// <returns></returns>
        public async Task<string> Save(TDocument document)
        {
            await CreateDatabaseIfNotExists(_database);
            await CreateDocumentCollectionIfNotExists(_database, _collection);

            var source = await _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(_database, _collection), document);

            return source.Resource.Id;
        }

        /// <summary>
        /// Get all documents from the specified collection
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TDocument>> Get()
        {
            await CreateDatabaseIfNotExists(_database);
            await CreateDocumentCollectionIfNotExists(_database, _collection);

            var documents = _client.CreateDocumentQuery<TDocument>(UriFactory.CreateDocumentCollectionUri(_database, _collection)).Where(_ => true);

            return documents.ToList();
        }

        /// <summary>
        /// Get a document by id
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns></returns>
        public async Task<TDocument> Get(string id)
        {
            await CreateDatabaseIfNotExists(_database);
            await CreateDocumentCollectionIfNotExists(_database, _collection);

            var query = _client.CreateDocumentQuery<TDocument>(UriFactory.CreateDocumentCollectionUri(_database, _collection));
            var enumerable = query.AsEnumerable();
            return enumerable.FirstOrDefault(doc => doc.id == id);
        }

        /// <summary>
        /// Builds a collection query
        /// </summary>
        /// <param name="predicate">Expression validator</param>
        /// <returns></returns>
        public async Task<ICollection<TDocument>> Query(Expression<Func<TDocument, bool>> predicate)
        {
            await CreateDatabaseIfNotExists(_database);
            await CreateDocumentCollectionIfNotExists(_database, _collection);

            return _client.CreateDocumentQuery<TDocument>(UriFactory.CreateDocumentCollectionUri(_database, _collection)).Where(predicate).ToList();
        }

        private async Task CreateDocumentCollectionIfNotExists(string databaseName, string collectionName)
        {
            try
            {
                await _client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    var collectionInfo = new DocumentCollection();
                    collectionInfo.Id = collectionName;

                    collectionInfo.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

                    await _client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(databaseName),
                        collectionInfo,
                        new RequestOptions { OfferThroughput = 400 });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateDatabaseIfNotExists(string databaseName)
        {
            try
            {
                await _client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseName));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDatabaseAsync(new Database { Id = databaseName });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
