//HintName: Gqlp_Definition_Intf.gen.cs
// Generated from Definition.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Definition;

public interface INumber
{
}

public interface IString
{
}

public interface I_Basic
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
  String AsString { get; }
  Unit AsUnit { get; }
}

public interface I_Internal
{
  Null AsNull { get; }
  Void AsVoid { get; }
}

public interface I_Key
{
  _Basic As_Basic { get; }
  _Internal As_Internal { get; }
  _Simple As_Simple { get; }
}

public interface I_Object
{
}

public interface I_Domain
{
}

public interface I_Dual
{
}

public interface I_Enum
{
}

public interface I_Input
{
}

public interface I_Output
{
}

public interface I_Union
{
}

public interface I_Simple
{
  _Enum As_Enum { get; }
  _Domain As_Domain { get; }
  _Union As_Union { get; }
}
