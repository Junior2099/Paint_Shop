## Solução em C
#include <stdio.h>
    #include <math.h>
    
    int main() {
        float area, litros_necessarios;
        int latas18, galoes36;
        float custo_latas, custo_galoes, custo_misto;
        
        printf("Digite o tamanho em metros quadrados da área a ser pintada: ");
        scanf("%f", &area);
        
        litros_necessarios = (area / 6.0) * 1.1;

        latas18 = ceil(litros_necessarios / 18.0);
        custo_latas = latas18 * 80.0;
        
        galoes36 = ceil(litros_necessarios / 3.6);
        custo_galoes = galoes36 * 25.0;
        
        latas18 = floor(litros_necessarios / 18.0);
        float litros_restantes = litros_necessarios - (latas18 * 18.0);
        galoes36 = ceil(litros_restantes / 3.6);
        
        if (galoes36 >= 5) {
            latas18 += 1;
            galoes36 = 0;
        }
        
        custo_misto = (latas18 * 80.0) + (galoes36 * 25.0);
        

        printf("\nResultados:\n");
        printf("\n1 - Comprar apenas latas de 18 litros:\n");
        printf("   Quantidade: %d latas\n", latas18);
        printf("   Custo: R$ %.2f\n", custo_latas);
        
        printf("\n2 - Comprar apenas galões de 3,6 litros:\n");
        printf("   Quantidade: %d galões\n", galoes36);
        printf("   Custo: R$ %.2f\n", custo_galoes);
        
        printf("\n3 - Misturar latas e galões (melhor opção):\n");
        printf("   Quantidade: %d latas e %d galões\n", latas18, galoes36);
        printf("   Custo: R$ %.2f\n", custo_misto);
        
        return 0;
    }
