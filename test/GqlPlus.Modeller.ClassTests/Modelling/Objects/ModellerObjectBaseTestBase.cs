using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling.Objects;

public abstract class ModellerObjectBaseTestBase<TAst, TModel, TBaseAst, TBaseModel>
  : ModellerClassTestBase<TAst, TModel>
  where TAst : IGqlpError
  where TModel : IModelBase
  where TBaseAst : class, IGqlpObjBase
  where TBaseModel : IObjBaseModel
{
  protected IModeller<TBaseAst, TBaseModel> ObjBase { get; } = MFor<TBaseAst, TBaseModel>();

  protected TBaseAst BaseReturns(string contents, [NotNull] Action<TBaseAst> astName, TBaseModel baseModel)
  {
    TBaseAst baseAst = For<TBaseAst>();
    astName(baseAst);
    baseAst.Description.Returns(contents);
    ObjBase.ToModel(baseAst, TypeKinds).Returns(baseModel);

    return baseAst;
  }
}
