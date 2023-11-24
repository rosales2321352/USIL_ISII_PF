using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class AnnotationTypeService : Service<AnnotationType>, IAnnotationTypeService
    {
        private readonly IAnnotationTypeRepository _annotationTypeRepository;

        public AnnotationTypeService(IAnnotationTypeRepository repository) : base(repository)
        {
            _annotationTypeRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllAnnotationTypes()
        {
            return await _annotationTypeRepository.GetAllAnnotationTypes();
        }
        public async Task<object> CreateAnnotationType(AnnotationTypeRequest request)
        {
            AnnotationType annotationType = new()
            {
                Name = request.Name
            };

            await _repository.Add(annotationType);
            request.TypeID = annotationType.AnnotationTypeID;
            return request;
        }
        public async Task<object> EditAnnotationType(AnnotationTypeRequest request)
        {
            int statusId = request.TypeID ?? 0;
            var annotationType = await _repository.GetById(statusId);

            annotationType.Name = request.Name;

            await _repository.Update(annotationType);
            return request;
        }

        public async Task DeleteAnnotationType(AnnotationTypeDelete request)
        {
            int statusId = request.AnnotationTypeID;
            var annotationType = await _repository.GetById(statusId);

            annotationType.IsAvailable = false;

            await _repository.Update(annotationType);
        }
    }
}