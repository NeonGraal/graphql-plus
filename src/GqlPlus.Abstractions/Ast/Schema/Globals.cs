namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchemaCategory
  : IAstDeclaration
  , IAstModifiers
  , IEquatable<IGqlpSchemaCategory>
{
  CategoryOption CategoryOption { get; }
  IAstTypeRef Output { get; }
}

public enum CategoryOption
{
  Parallel,
  Sequential,
  Single,
}

public interface IGqlpSchemaDirective
  : IAstDeclaration
  , IEquatable<IGqlpSchemaDirective>
{
  IGqlpInputParam? Parameter { get; }
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

public interface IGqlpSchemaOption
  : IAstDeclaration
  , IEquatable<IGqlpSchemaOption>
{
  IEnumerable<IGqlpSchemaSetting> Settings { get; }
}

public interface IGqlpSchemaSetting
  : IAstNamed
  , IEquatable<IGqlpSchemaSetting>
{
  IAstConstant Value { get; }
}
