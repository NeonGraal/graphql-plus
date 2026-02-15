using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchemaCategory
  : IGqlpDeclaration
  , IGqlpModifiers
  , IEquatable<IGqlpSchemaCategory>
{
  CategoryOption CategoryOption { get; }
  IGqlpTypeRef Output { get; }
}

public enum CategoryOption
{
  Parallel,
  Sequential,
  Single,
}

public interface IGqlpSchemaDirective
  : IGqlpDeclaration
  , IEquatable<IGqlpSchemaDirective>
{
  IEnumerable<IGqlpInputParam> Params { get; }
  DirectiveOption DirectiveOption { get; }
  DirectiveLocation Locations { get; }
}

public enum DirectiveOption
{
  Unique,
  Repeatable,
}

[Flags]
public enum DirectiveLocation
{
  Operation = 0x01,
  Variable = 0x02,
  Field = 0x04,
  Inline = 0x08,
  Spread = 0x10,
  Fragment = 0x20,

  None = 0x00,
  All = 0xff,
}

public interface IGqlpSchemaOperation
  : IGqlpDeclaration, IGqlpDirectives, IGqlpModifiers
{
  string Category { get; }

  IEnumerable<IGqlpVariable> Variables { get; }
  IGqlpArg? Arg { get; }
  IEnumerable<IGqlpSelection>? Selections { get; }

  IEnumerable<IGqlpFragment> Fragments { get; }
}

public interface IGqlpSchemaOption
  : IGqlpDeclaration
  , IEquatable<IGqlpSchemaOption>
{
  IEnumerable<IGqlpSchemaSetting> Settings { get; }
}

public interface IGqlpSchemaSetting
  : IGqlpNamed
  , IEquatable<IGqlpSchemaSetting>
{
  IGqlpConstant Value { get; }
}
