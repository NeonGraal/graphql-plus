namespace GqlPlus.Ast.Operation;

public interface IAstSelection
  : IAstOpSelection;

public interface IAstField
  : IAstOpField
  , IAstSelection
  , IAstSelections
  , IEquatable<IAstField>;

public interface IAstInline
  : IAstOpInline
  , IAstSelection
  , IAstSelections
  , IEquatable<IAstInline>;

public interface IAstSpread
  : IAstOpSpread
  , IAstSelection
  , IEquatable<IAstSpread>;

public interface IAstArg
  : IAstValue<IAstArg>
  , IEquatable<IAstArg>
{
  string? Variable { get; }
  IAstConstant? Constant { get; }
}
