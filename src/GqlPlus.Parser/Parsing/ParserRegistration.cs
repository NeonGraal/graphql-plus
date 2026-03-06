namespace GqlPlus.Parsing;

internal enum ParserRegistrationKind
{
  Single,
  SingleInterface,
  Array,
  ArrayInterface,
}

internal record ParserRegistration(Type For, Type Service, ParserRegistrationKind Kind);
