namespace GqlPlus.Ast.Operation;

public interface IAstSelection
  : IAstError
  , IAstDirectives
  , IAstModifiers;

public interface IAstField
  : IAstIdentified
  , IAstSelection
  , IAstSelections
  , IEquatable<IAstField>
{
  string? FieldAlias { get; }
  IAstArg? Arg { get; }
}

public interface IAstInline
  : IAstAbbreviated
  , IAstSelection
  , IAstSelections
  , IEquatable<IAstInline>
{
  string? OnType { get; }
}

public interface IAstSpread
  : IAstIdentified
  , IAstSelection
  , IEquatable<IAstSpread>;

public interface IAstArg
  : IAstValue<IAstArg>
  , IEquatable<IAstArg>
{
  string? Variable { get; }
  IAstConstant? Constant { get; }
}
