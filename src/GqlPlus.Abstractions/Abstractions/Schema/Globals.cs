namespace GqlPlus.Abstractions.Schema;

public interface IGqlpSchemaCategory
  : IGqlpDeclaration, IGqlpModifiers
{
  CategoryOption CategoryOption { get; }
  string Output { get; }
}

public enum CategoryOption
{
  Parallel,
  Sequential,
  Single,
}

public interface IGqlpCollection
{
  //* Value Opt is invalid
  ModifierKind CollectionKind { get; }
  IGqlpFieldKey? Key { get; }
}

public interface IGqlpSchemaDirective
  : IGqlpDeclaration
{
  IEnumerable<IGqlpInputParameter> Parameters { get; }
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
  : IGqlpDeclaration
{
  IEnumerable<IGqlpSchemaSetting> Settings { get; }
}

public interface IGqlpSchemaSetting
  : IGqlpNamed, IGqlpDescribed
{
  IGqlpConstant Value { get; }
}
