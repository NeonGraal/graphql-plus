//HintName: Gqlp_parent-descr+Input_Intf.gen.cs
// Generated from parent-descr+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Input;

public interface IPrntDescrInp
  : IRefPrntDescrInp
{
}

public interface IRefPrntDescrInp
{
  Number parent { get; }
  String AsString { get; }
}
