namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjArg<TObjArgAst, TObjArg>
  : ModellerBase<TObjArgAst, TObjArg>
  where TObjArgAst : IGqlpObjArg
  where TObjArg : IModelBase
{ }
