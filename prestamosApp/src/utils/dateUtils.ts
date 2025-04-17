// utils/dateUtils.ts
import { formatInTimeZone } from 'date-fns-tz';
import { es } from 'date-fns/locale';

export const formatUTCDate = (
  dateString: string | null,
  timeZone: string = 'America/Argentina/Buenos_Aires',
  formatStr: string = 'dd/MM/yyyy HH:mm'
) => {
  if (!dateString) return 'N/A';
  
  try {
    // Normaliza fechas de SQL Server
    const normalizedDate = dateString.includes(' ') 
      ? dateString.replace(' ', 'T') + 'Z' 
      : dateString;
    
    return formatInTimeZone(
      new Date(normalizedDate),
      timeZone,
      formatStr,
      { locale: es }
    );
  } catch (error) {
    console.error('Error formateando fecha:', error);
    return 'Fecha inválida';
  }
};