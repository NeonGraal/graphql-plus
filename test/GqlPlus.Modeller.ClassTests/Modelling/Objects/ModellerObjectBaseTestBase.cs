using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling.Objects;

public abstract class ModellerObjectBaseTestBase<TAst, TModel, TBaseModel>
  : ModellerClassTestBase<TAst, TModel>
  where TAst : IAstError
  where TModel : IModelBase
  where TBaseModel : IObjBaseModel
{
  protected IModeller<IAstObjBase, TBaseModel> ObjBase { get; } = MFor<IAstObjBase, TBaseModel>();

  protected IAstObjBase BaseReturns(string contents, [NotNull] Action<IAstObjBase> astName, TBaseModel baseModel)
  {
    IAstObjBase baseAst = A.Descr<IAstObjBase>(contents);
    astName(baseAst);

    ObjBase.ToModel(baseAst, TypeKinds).Returns(baseModel);

    return baseAst;
  }
}
