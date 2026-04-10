namespace GqlPlus.Abstractions.Schema;

public interface IAstSchemaCategory
  : IAstDeclaration
  , IAstModifiers
  , IEquatable<IAstSchemaCategory>
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

public interface IAstSchemaDirective
  : IAstDeclaration
  , IEquatable<IAstSchemaDirective>
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

public interface IAstSchemaOption
  : IAstDeclaration
  , IEquatable<IAstSchemaOption>
{
  IEnumerable<IAstSchemaSetting> Settings { get; }
}

public interface IAstSchemaSetting
  : IAstNamed
  , IEquatable<IAstSchemaSetting>
{
  IAstConstant Value { get; }
}
