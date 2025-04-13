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
{
  public _Simple As_Simple { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}

public interface I_Simple
{
  Boolean AsBoolean { get; }
  _DomainValue < I@020/0009 _DomainKind.Number I@039/0009 Number > As_DomainValue { get; }
  _DomainValue < I@020/0010 _DomainKind.String I@039/0010 String > As_DomainValue { get; }
  _EnumValue As_EnumValue { get; }
}
public class Output_Simple
{
  public Boolean AsBoolean { get; set; }
  public _DomainValue < I@020/0009 _DomainKind.Number I@039/0009 Number > As_DomainValue { get; set; }
  public _DomainValue < I@020/0010 _DomainKind.String I@039/0010 String > As_DomainValue { get; set; }
  public _EnumValue As_EnumValue { get; set; }
}

public interface I_ConstantList
{
  _Constant As_Constant { get; }
}
public class Output_ConstantList
{
  public _Constant As_Constant { get; set; }
}

public interface I_ConstantMap
{
  _Constant As_Constant { get; }
}
public class Output_ConstantMap
{
  public _Constant As_Constant { get; set; }
}

public interface I_Collections
{
  _Modifier < I@017/0023 _ModifierKind.List > As_Modifier { get; }
  _ModifierKeyed < I@022/0024 _ModifierKind.Dictionary > As_ModifierKeyed { get; }
  _ModifierKeyed < I@022/0025 _ModifierKind.TypeParam > As_ModifierKeyed { get; }
}
public class Output_Collections
{
  public _Modifier < I@017/0023 _ModifierKind.List > As_Modifier { get; set; }
  public _ModifierKeyed < I@022/0024 _ModifierKind.Dictionary > As_ModifierKeyed { get; set; }
  public _ModifierKeyed < I@022/0025 _ModifierKind.TypeParam > As_ModifierKeyed { get; set; }
}

public interface I_ModifierKeyed
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}
public class Output_ModifierKeyed
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public interface I_Modifiers
{
  _Modifier < I@017/0035 _ModifierKind.Optional > As_Modifier { get; }
  _Collections As_Collections { get; }
}
public class Output_Modifiers
{
  public _Modifier < I@017/0035 _ModifierKind.Optional > As_Modifier { get; set; }
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

public interface I_Modifier
{
  $kind modifierKind { get; }
}
public class Output_Modifier
{
  public $kind modifierKind { get; set; }
}
