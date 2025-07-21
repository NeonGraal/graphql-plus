//HintName: Gqlp_Intro_Built-In_Impl.gen.cs
// Generated from Intro_Built-In.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Built_In;
public class Output_Constant
  : I_Constant
{
  public _SimpleValue As_SimpleValue { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}
public class Output_SimpleValue
  : I_SimpleValue
{
  public _DomainValue<_DomainKind, Boolean> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, _EnumValue> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, Number> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, String> As_DomainValue { get; set; }
}
public class Output_ConstantList
  : I_ConstantList
{
  public _Constant As_Constant { get; set; }
}
public class Output_ConstantMap
  : I_ConstantMap
{
  public _Constant As_Constant { get; set; }
}
public class Output_Collections
  : I_Collections
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
}
public class Output_ModifierKeyed<Tkind>
  : Output_Modifier
  , I_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}
public class Output_Modifiers
  : I_Modifiers
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}
public class Output_Modifier<Tkind>
  : I_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}
