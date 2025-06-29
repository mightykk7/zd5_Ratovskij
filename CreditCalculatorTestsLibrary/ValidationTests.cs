using zd4_ratovskij;
namespace CreditCalculatorTestsLibrary
{
    [TestClass]
    public class ValidationTests
    {
        //-----����� ���� creditSum-----//
        [TestMethod]
        public void CreditSum_100_Exception()
        {
            double credit = 100;
            try
            {
                CreditCalculator.CheckValidCreditSum(credit);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("����������� ����� ������� 10 000 ������", ex.Message);
            }
        }
        [TestMethod]
        public void CreditSum_1000000000_Exception()
        {
            double credit = 1000000000;
            try
            {
                CreditCalculator.CheckValidCreditSum(credit);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������������ ����� ������� 100 000 000 ������", ex.Message);
            }
        }
        [TestMethod]
        public void CreditSum_1000000_Correct()
        {
            double credit = 1000000;
            try
            {
                CreditCalculator.CheckValidCreditSum(credit);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void CreditSum_100000000_Correct()
        {
            double credit = 100000000;
            try
            {
                CreditCalculator.CheckValidCreditSum(credit);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void CreditSum_10000_Correct()
        {
            double credit = 10000;
            try
            {
                CreditCalculator.CheckValidCreditSum(credit);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //-----����� ���� term-----//
        [TestMethod]
        public void Term_0_Exception()
        {
            int term = 0;
            try
            {
                CreditCalculator.CheckValidTerm(term);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("����������� ���� 1 �����", ex.Message);
            }
        }
        [TestMethod]
        public void Term_400_Exception()
        {
            int term = 400;
            try
            {
                CreditCalculator.CheckValidTerm(term);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������������ ���� 360 ������� (30 ���)", ex.Message);
            }
        }
        [TestMethod]
        public void Term_12_Correct()
        {
            int term = 12;
            try
            {
                CreditCalculator.CheckValidTerm(term);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Term_1_Correct()
        {
            int term = 1;
            try
            {
                CreditCalculator.CheckValidTerm(term);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Term_360_Correct()
        {
            int term = 360;
            try
            {
                CreditCalculator.CheckValidTerm(term);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        //------����� � ���� username-------//
        [TestMethod]
        public void Username_Standart_Correct()
        {
            string username = "���� ������";
            try
            {
                WelcomePage.CheckValidUsername(username);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Username_MinLength_Correct()
        {
            string username = "��";
            try
            {
                WelcomePage.CheckValidUsername(username);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Username_MaxLength_Correct()
        {
            string username = "���� � ��������";
            try
            {
                WelcomePage.CheckValidUsername(username);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Username_1char_Exception()
        {
            string username = "�";
            try
            {
                WelcomePage.CheckValidUsername(username);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("����������� ����� ����� ������������ 2 �������", ex.Message);
            }
        }
        [TestMethod]
        public void Username_16char_Exception()
        {
            string username = "��������� ������";
            try
            {
                WelcomePage.CheckValidUsername(username);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������������ ����� ����� ������������ 15 ��������", ex.Message);
            }
        }
        [TestMethod]
        public void Username_NotAllowedChars_Exception()
        {
            string username = "������1488!";
            try
            {
                WelcomePage.CheckValidUsername(username);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("��� ������������ ����� ��������� ������ ����� � �������", ex.Message);
            }
        }
        //------����� � ���� username-------//
        [TestMethod]
        public void Password_Standart_Correct()
        {
            string password = "q1w2e3r4t5";
            try
            {
                WelcomePage.CheckValidPassword(password);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Password_MinChars_Correct()
        {
            string password = "q1w2e3r4";
            try
            {
                WelcomePage.CheckValidPassword(password);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Password_MaxChars_Correct()
        {
            string password = "q1w2e3r4q1w2e3r4";
            try
            {
                WelcomePage.CheckValidPassword(password);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void Password_4chars_Exception()
        {
            string password = "qad6";
            try
            {
                WelcomePage.CheckValidPassword(password);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������ ������ ��������� ������� 8 ��������", ex.Message);
            }
        }
        [TestMethod]
        public void Password_20chars_Exception()
        {
            string password = "qad6q1w2e3r4q1w2e3r4";
            try
            {
                WelcomePage.CheckValidPassword(password);
                Assert.Fail("��������� ����������");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������ ������ ��������� �������� 16 ��������", ex.Message);
            }
        }
    }
}