//HintName: Model_Intro_Domain.gen.cs
// Generated from Intro_Domain.graphql+

/*
*/

namespace GqlTest.Model_Intro_Domain;

public enum _DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface I_TypeDomain
{
  _BaseDomain < I@019/0004 _DomainKind.Boolean I@039/0004 _DomainTrueFalse I@056/0004 _DomainItemTrueFalse > As_BaseDomain { get; }
  _BaseDomain < I@019/0005 _DomainKind.Enum I@036/0005 _DomainLabel I@049/0005 _DomainItemLabel > As_BaseDomain { get; }
  _BaseDomain < I@019/0006 _DomainKind.Number I@038/0006 _DomainRange I@051/0006 _DomainItemRange > As_BaseDomain { get; }
  _BaseDomain < I@019/0007 _DomainKind.String I@038/0007 _DomainRegex I@051/0007 _DomainItemRegex > As_BaseDomain { get; }
}
public class Output_TypeDomain
{
  public _BaseDomain < I@019/0004 _DomainKind.Boolean I@039/0004 _DomainTrueFalse I@056/0004 _DomainItemTrueFalse > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0005 _DomainKind.Enum I@036/0005 _DomainLabel I@049/0005 _DomainItemLabel > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0006 _DomainKind.Number I@038/0006 _DomainRange I@051/0006 _DomainItemRange > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0007 _DomainKind.String I@038/0007 _DomainRegex I@051/0007 _DomainItemRegex > As_BaseDomain { get; set; }
}

public interface I_DomainRef
{
  $kind domainKind { get; }
}
public class Output_DomainRef
{
  public $kind domainKind { get; set; }
}

public interface I_BaseDomain
{
  $domain domainKind { get; }
}
public class Output_BaseDomain
{
  public $domain domainKind { get; set; }
}

public interface I_BaseDomainItem
{
  Boolean exclude { get; }
}
public class Dual_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public interface I_DomainItem
{
  _Identifier domain { get; }
}
public class Output_DomainItem
{
  public _Identifier domain { get; set; }
}

public interface I_DomainValue
{
  $value value { get; }
}
public class Output_DomainValue
{
  public $value value { get; set; }
}

public interface I_DomainTrueFalse
{
  Boolean value { get; }
}
public class Dual_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public interface I_DomainItemTrueFalse
{
}
public class Output_DomainItemTrueFalse
{
}

public interface I_DomainLabel
{
  _EnumValue label { get; }
}
public class Output_DomainLabel
{
  public _EnumValue label { get; set; }
}

public interface I_DomainItemLabel
{
}
public class Output_DomainItemLabel
{
}

public interface I_DomainRange
{
  Number lower { get; }
  Number upper { get; }
}
public class Dual_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public interface I_DomainItemRange
{
}
public class Output_DomainItemRange
{
}

public interface I_DomainRegex
{
  String pattern { get; }
}
public class Dual_DomainRegex
{
  public String pattern { get; set; }
}

public interface I_DomainItemRegex
{
}
public class Output_DomainItemRegex
{
}
