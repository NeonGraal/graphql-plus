//HintName: Model_Intro_Built-In.gen.cs
// Generated from Intro_Built-In.graphql+

/*
*/

namespace GqlTest.Model_Intro_Built_In;

public interface I_Constant
{
  _Simple As_Simple { get; }
  _ConstantList As_ConstantList { get; }
  _ConstantMap As_ConstantMap { get; }
}
public class Output_Constant
  : I_Constant
{
  public _Simple As_Simple { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}

public interface I_Simple
{
  Boolean AsBoolean { get; }
  _DomainValue As_DomainValue { get; }
  _DomainValue As_DomainValue { get; }
  _EnumValue As_EnumValue { get; }
}
public class Output_Simple
  : I_Simple
{
  public Boolean AsBoolean { get; set; }
  public _DomainValue As_DomainValue { get; set; }
  public _DomainValue As_DomainValue { get; set; }
  public _EnumValue As_EnumValue { get; set; }
}

public interface I_ConstantList
{
  _Constant As_Constant { get; }
}
public class Output_ConstantList
  : I_ConstantList
{
  public _Constant As_Constant { get; set; }
}

public interface I_ConstantMap
{
  _Constant As_Constant { get; }
}
public class Output_ConstantMap
  : I_ConstantMap
{
  public _Constant As_Constant { get; set; }
}

public interface I_Collections
{
  _Modifier As_Modifier { get; }
  _ModifierKeyed As_ModifierKeyed { get; }
  _ModifierKeyed As_ModifierKeyed { get; }
}
public class Output_Collections
  : I_Collections
{
  public _Modifier As_Modifier { get; set; }
  public _ModifierKeyed As_ModifierKeyed { get; set; }
  public _ModifierKeyed As_ModifierKeyed { get; set; }
}

public interface I_ModifierKeyed<Tkind>
  : I_Modifier
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}
public class Output_ModifierKeyed<Tkind>
  : Output_Modifier
  , I_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public interface I_Modifiers
{
  _Modifier As_Modifier { get; }
  _Collections As_Collections { get; }
}
public class Output_Modifiers
  : I_Modifiers
{
  public _Modifier As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}

public enum _ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface I_Modifier<Tkind>
{
  Tkind modifierKind { get; }
}
public class Output_Modifier<Tkind>
  : I_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}
