using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling.Objects;

public abstract class ModellerObjectBaseTestBase<TAst, TModel, TBaseModel>
  : ModellerClassTestBase<TAst, TModel>
  where TAst : IGqlpError
  where TModel : IModelBase
  where TBaseModel : IObjBaseModel
{
  protected IModeller<IGqlpObjBase, TBaseModel> ObjBase { get; } = MFor<IGqlpObjBase, TBaseModel>();

  protected IGqlpObjBase BaseReturns(string contents, [NotNull] Action<IGqlpObjBase> astName, TBaseModel baseModel)
  {
    IGqlpObjBase baseAst = A.Descr<IGqlpObjBase>(contents);
    astName(baseAst);

    ObjBase.ToModel(baseAst, TypeKinds).Returns(baseModel);

    return baseAst;
  }
}
