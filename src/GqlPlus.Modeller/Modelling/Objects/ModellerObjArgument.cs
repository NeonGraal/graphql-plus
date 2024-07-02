namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjArgument<TObjArgAst, TObjArg>
  : ModellerBase<TObjArgAst, TObjArg>
  where TObjArgAst : IGqlpObjArgument
  where TObjArg : IModelBase
{ }
