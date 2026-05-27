namespace GqlPlus.Ast.Operation;

public interface IAstSelection
  : IAstError
  , IAstDirectives
{ }

public interface IAstField
  : IAstIdentified
  , IAstSelection
  , IAstModifiers
  , IAstSelections
{
  string? FieldAlias { get; }
  IAstArg? Arg { get; }
}

public interface IAstInline
  : IAstAbbreviated
  , IAstSelection
  , IAstSelections
  , IAstModifiers
  , IEquatable<IAstInline>
{
  string? OnType { get; }
}

public interface IAstSpread
  : IAstIdentified
  , IAstSelection
  , IAstModifiers
{ }

public interface IAstArg
  : IAstValue<IAstArg>
  , IEquatable<IAstArg>
{
  string? Variable { get; }
  IAstConstant? Constant { get; }
}
