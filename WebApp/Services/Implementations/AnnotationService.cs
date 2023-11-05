using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class AnnotationService : Service<Annotation>, IAnnotationService
    {
        private readonly IAnnotationRepository _annotationRepository;
        public AnnotationService(IAnnotationRepository repository) : base(repository)
        {
            _annotationRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllAnnotations()
        {

            return await _annotationRepository.GetAllAnnotations();
        }

        public async Task<object> GetAnnotationDetail(int id)
        {
            return await _annotationRepository.GetAnnotationDetail(id);
        }

        public async Task<IEnumerable<object>> GetAnnotationsByClient(int id)
        {
            return await _annotationRepository.GetAnnotationsByClient(id);
        }

        public async Task CreateAnnotation(AnnotationRequest request)
        {
            Annotation annotation = new ()
            {
                Title = request.Title,
                Description = request.Description,
                AnnotationTypeID = request.AnnotationTypeID,
                SellerID = request.SellerID,
                ClientID = request.ClientID,
            };

            await _repository.Add(annotation);
        }

        public async Task EditAnnotation(AnnotationUpdate request)
        {
            var annotation = await _repository.GetById(request.AnnotationID);
            
            annotation.Title = request.Title;
            annotation.Description = request.Description;
            annotation.AnnotationTypeID = request.AnnotationTypeID;

            await _repository.Update(annotation);
        }

        public async Task DeleteAnnotation(AnnotationDelete request)
        {
            var annotation = await _repository.GetById(request.AnnotationID);

            await _repository.Delete(annotation);
        }
        
    }
}